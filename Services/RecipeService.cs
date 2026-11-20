using ExamProject.Models;
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using static Supabase.Postgrest.Constants;

namespace ExamProject.Services;

/// <summary>
/// All talking to Supabase happens here, so the pages stay simple.
/// Every method is async because every call goes over the network.
/// </summary>
public class RecipeService
{
    private readonly Supabase.Client _db;

    public RecipeService(Supabase.Client db) => _db = db;

    // ───────────── READ ─────────────

    /// <summary>
    /// The recipe list. HABIT 2: the database does the filtering and the paging,
    /// so only the rows we show travel to the app. (Used by Home, with limit 6.)
    /// </summary>
    public async Task<List<Recipe>> SearchAsync(string? query, string? category, int limit = 50)
    {
        var table = _db.From<Recipe>()
            .Where(r => r.DeletedAt == null);                     // hide soft-deleted recipes

        if (!string.IsNullOrWhiteSpace(category))
            table = table.Where(r => r.Category == category);     // WHERE category = ...

        if (!string.IsNullOrWhiteSpace(query))
        {
            // commas and brackets have a special meaning inside an "or" filter
            var term = query.Trim().Replace(",", " ").Replace("(", " ").Replace(")", " ");
            var like = $"%{term}%";

            // match the text in the name OR description OR category (case-insensitive)
            table = table.Or(new List<IPostgrestQueryFilter>
            {
                new QueryFilter("name", Operator.ILike, like),
                new QueryFilter("description", Operator.ILike, like),
                new QueryFilter("category", Operator.ILike, like)
            });
        }

        var res = await table
            .Order(r => r.Name, Ordering.Ascending)
            .Range(0, limit - 1)
            .Get();                                               // sends GET
        return res.Models;
    }

    /// <summary>The category names for the dropdown and pills. Only ONE column is requested.</summary>
    public async Task<List<string>> GetCategoriesAsync()
    {
        var res = await _db.From<Recipe>()
            .Select("category")
            .Where(r => r.DeletedAt == null)
            .Get();
        return res.Models.Select(r => r.Category).Distinct().OrderBy(c => c).ToList();
    }

    /// <summary>One recipe with its ingredients: 2 requests, always 2, never one per ingredient.</summary>
    public async Task<Recipe?> GetByIdAsync(int id)
    {
        var res = await _db.From<Recipe>()
            .Where(r => r.Id == id)
            .Where(r => r.DeletedAt == null)
            .Get();
        var recipe = res.Models.FirstOrDefault();
        if (recipe is null) return null;

        var ingredients = await _db.From<Ingredient>()
            .Where(i => i.RecipeId == id)
            .Order(i => i.Id, Ordering.Ascending)
            .Get();
        recipe.Ingredients = ingredients.Models;
        return recipe;
    }

    // ───────────── CREATE ─────────────

    public async Task<int> AddAsync(Recipe recipe)
    {
        var res = await _db.From<Recipe>().Insert(recipe);        // sends POST
        var saved = res.Models.First();                           // the row, now with its new id
        await InsertIngredientsAsync(saved.Id, recipe.Ingredients);
        return saved.Id;
    }

    // ───────────── UPDATE ─────────────

    public async Task UpdateAsync(Recipe r)
    {
        await _db.From<Recipe>()
            .Where(x => x.Id == r.Id)                             // ALWAYS Where, or every row changes
            .Set(x => x.Name, r.Name)
            .Set(x => x.Description, r.Description)
            .Set(x => x.Category, r.Category)
            .Set(x => x.ImageUrl, r.ImageUrl)
            .Set(x => x.PrepMinutes, r.PrepMinutes)
            .Set(x => x.CookMinutes, r.CookMinutes)
            .Set(x => x.Servings, r.Servings)
            .Set(x => x.Tags, r.Tags)
            .Set(x => x.Steps, r.Steps)
            .Update();                                            // sends PATCH

        // Ingredients: replace the old list with the edited one.
        await _db.From<Ingredient>().Where(i => i.RecipeId == r.Id).Delete();
        await InsertIngredientsAsync(r.Id, r.Ingredients);
    }

    // ───────────── DELETE (soft) ─────────────

    /// <summary>Soft delete: the row stays; deleted_at is filled in; every read skips it.</summary>
    public async Task SoftDeleteAsync(int id)
    {
        await _db.From<Recipe>()
            .Where(r => r.Id == id)
            .Set(r => r.DeletedAt, DateTime.UtcNow)
            .Update();                                            // an update, not a DELETE
    }

    // ───────────── helper ─────────────

    private async Task InsertIngredientsAsync(int recipeId, List<Ingredient> items)
    {
        if (items.Count == 0) return;
        foreach (var item in items) item.RecipeId = recipeId;     // no network inside this loop
        await _db.From<Ingredient>().Insert(items);               // HABIT 3: ONE request for all rows
    }
}