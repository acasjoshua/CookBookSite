using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ExamProject.Models;

// One class per table: Recipe <-> public.recipes
[Table("recipes")]
public class Recipe : BaseModel
{
    [PrimaryKey("id", false)]            // false = never send the id on insert; the database makes it
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("category")]
    public string Category { get; set; } = string.Empty;

    [Column("image_url")]
    public string ImageUrl { get; set; } = string.Empty;

    [Column("prep_minutes")]
    public int PrepMinutes { get; set; }

    [Column("cook_minutes")]
    public int CookMinutes { get; set; }

    [Column("servings")]
    public int Servings { get; set; }

    [Column("tags")]
    public List<string> Tags { get; set; } = new();

    [Column("steps")]
    public List<string> Steps { get; set; } = new();

    // null until the recipe is soft-deleted
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

    // NOT columns. "internal" keeps them out of what gets sent to Supabase,
    // while your pages and RecipeService can still use them.
    [JsonIgnore]
    internal List<Ingredient> Ingredients { get; set; } = new();

    [JsonIgnore]
    internal int TotalMinutes => PrepMinutes + CookMinutes;
}