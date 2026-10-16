using ExamProject.Models;

namespace ExamProject.Services;

public class RecipeService
{
    private readonly List<Recipe> _recipes = new()
    {
        new Recipe
        {
            Id = 1, Name = "Chicken Adobo", Category = "Main Dish",
            Description = "The Philippines' unofficial national dish: chicken braised in soy sauce, vinegar and garlic.",
            ImageUrl = "images/chicken-adobo.jpg", PrepMinutes = 15, CookMinutes = 40, Servings = 4,
            Tags = new() { "chicken", "filipino", "rice", "savory" },
            Ingredients = new()
            {
                new("1 kg", "chicken thighs and drumsticks"), new("1/2 cup", "soy sauce"),
                new("1/3 cup", "cane vinegar"), new("1 head", "garlic, crushed"),
                new("1 tsp", "whole peppercorns"), new("3", "bay leaves"), new("1 cup", "water")
            },
            Steps = new()
            {
                "Combine chicken, soy sauce, vinegar, garlic, peppercorns and bay leaves. Marinate for 30 minutes.",
                "Transfer everything to a pot, add water and bring to a boil without stirring.",
                "Lower the heat, cover and simmer for 30-35 minutes until the chicken is tender.",
                "Uncover and let the sauce reduce until slightly thick. Serve with hot rice."
            }
        },
        new Recipe
        {
            Id = 2, Name = "Pork Sinigang", Category = "Soup",
            Description = "A sour and savory pork soup with vegetables, soured with tamarind.",
            ImageUrl = "images/pork-sinigang.jpg", PrepMinutes = 15, CookMinutes = 60, Servings = 5,
            Tags = new() { "pork", "soup", "sour", "filipino" },
            Ingredients = new()
            {
                new("750 g", "pork ribs"), new("1 packet", "sinigang mix (tamarind)"),
                new("1", "onion, quartered"), new("2", "tomatoes, quartered"),
                new("1", "radish, sliced"), new("1 bunch", "kangkong (water spinach)"),
                new("2", "long green chilies"), new("2 L", "water"), new("2 tbsp", "fish sauce")
            },
            Steps = new()
            {
                "Boil the water with onion and tomatoes, then add the pork ribs.",
                "Skim the scum and simmer for 45-60 minutes until the pork is tender.",
                "Add the radish and the sinigang mix and cook for 5 minutes.",
                "Add chilies and kangkong, season with fish sauce and serve hot."
            }
        },
        new Recipe
        {
            Id = 3, Name = "Kinilaw na Tanigue", Category = "Appetizer",
            Description = "A Visayan ceviche: fresh fish cured in vinegar and calamansi with ginger and chili.",
            ImageUrl = "images/kinilaw.jpg", PrepMinutes = 20, CookMinutes = 0, Servings = 4,
            Tags = new() { "fish", "seafood", "raw", "visayan", "cebu" },
            Ingredients = new()
            {
                new("500 g", "fresh tanigue (Spanish mackerel), cubed"), new("1/2 cup", "coconut or cane vinegar"),
                new("5", "calamansi, juiced"), new("1 thumb", "ginger, minced"),
                new("1", "red onion, thinly sliced"), new("2", "siling labuyo, chopped"), new("1 tsp", "salt")
            },
            Steps = new()
            {
                "Wash the fish cubes briefly in vinegar and drain.",
                "In a bowl, combine fish, fresh vinegar, calamansi juice, ginger, onion and chilies.",
                "Season with salt and toss gently.",
                "Chill for 10-15 minutes and serve immediately."
            }
        },
        new Recipe
        {
            Id = 4, Name = "Lechon Kawali", Category = "Main Dish",
            Description = "Crispy deep-fried pork belly with crackling skin and juicy meat.",
            ImageUrl = "images/lechon-kawali.jpg", PrepMinutes = 20, CookMinutes = 90, Servings = 6,
            Tags = new() { "pork", "crispy", "fried", "filipino" },
            Ingredients = new()
            {
                new("1 kg", "pork belly slab"), new("2 tbsp", "salt"), new("1 tbsp", "peppercorns"),
                new("4", "bay leaves"), new("1 head", "garlic"), new("1 L", "cooking oil for frying")
            },
            Steps = new()
            {
                "Boil pork with salt, peppercorns, bay leaves and garlic for 45 minutes until tender.",
                "Drain and let it air-dry completely, ideally in the fridge for a few hours.",
                "Heat oil to medium-high and carefully fry the pork until golden and blistered.",
                "Rest briefly, chop into pieces and serve with liver sauce or spiced vinegar."
            }
        },
        new Recipe
        {
            Id = 5, Name = "Pancit Canton", Category = "Noodles",
            Description = "Stir-fried egg noodles with vegetables and meat, a staple at celebrations.",
            ImageUrl = "images/pancit-canton.jpg", PrepMinutes = 15, CookMinutes = 20, Servings = 4,
            Tags = new() { "noodles", "chicken", "vegetables", "filipino", "birthday" },
            Ingredients = new()
            {
                new("250 g", "pancit canton noodles"), new("200 g", "chicken breast, sliced"),
                new("1", "carrot, julienned"), new("1 cup", "cabbage, shredded"),
                new("4 cloves", "garlic, minced"), new("3 tbsp", "soy sauce"),
                new("1 tbsp", "oyster sauce"), new("1.5 cups", "chicken broth"), new("1", "calamansi")
            },
            Steps = new()
            {
                "Sauté garlic and chicken until cooked through.",
                "Add carrot and cabbage, then pour in broth, soy sauce and oyster sauce.",
                "Bring to a simmer, add the noodles and toss until the liquid is absorbed.",
                "Serve with calamansi on the side."
            }
        },
        new Recipe
        {
            Id = 6, Name = "Tinolang Manok", Category = "Soup",
            Description = "A comforting ginger chicken soup with green papaya and chili leaves.",
            ImageUrl = "images/tinola.jpg", PrepMinutes = 10, CookMinutes = 35, Servings = 4,
            Tags = new() { "chicken", "soup", "ginger", "filipino", "healthy" },
            Ingredients = new()
            {
                new("1 kg", "chicken, cut into pieces"), new("1 thumb", "ginger, sliced"),
                new("1", "onion, sliced"), new("1", "green papaya, wedged"),
                new("1 bunch", "chili leaves (dahon ng sili)"), new("1.5 L", "water"), new("2 tbsp", "fish sauce")
            },
            Steps = new()
            {
                "Sauté ginger and onion, then add chicken and fish sauce until lightly browned.",
                "Pour in water and simmer for 25 minutes.",
                "Add the green papaya and cook until tender.",
                "Stir in chili leaves, cook for 1 minute and serve."
            }
        },
        new Recipe
        {
            Id = 7, Name = "Leche Flan", Category = "Dessert",
            Description = "A silky, rich caramel custard made with egg yolks and condensed milk.",
            ImageUrl = "images/leche-flan.jpg", PrepMinutes = 20, CookMinutes = 50, Servings = 8,
            Tags = new() { "dessert", "sweet", "egg", "caramel", "filipino" },
            Ingredients = new()
            {
                new("10", "egg yolks"), new("1 can (14 oz)", "condensed milk"),
                new("1 can (12 oz)", "evaporated milk"), new("1 tsp", "vanilla extract"),
                new("1/2 cup", "sugar (for caramel)")
            },
            Steps = new()
            {
                "Melt the sugar in a llanera (mold) until golden brown and swirl to coat the base.",
                "Gently mix yolks, condensed milk, evaporated milk and vanilla. Strain the mixture.",
                "Pour into the mold, cover tightly with foil.",
                "Steam on low heat for 45-50 minutes. Cool, chill, then unmold and serve."
            }
        },
        new Recipe
        {
            Id = 8, Name = "Spaghetti Carbonara", Category = "Pasta",
            Description = "Classic Roman pasta with eggs, cheese, crispy bacon and black pepper.",
            ImageUrl = "images/carbonara.jpg", PrepMinutes = 10, CookMinutes = 15, Servings = 2,
            Tags = new() { "pasta", "italian", "bacon", "egg", "quick" },
            Ingredients = new()
            {
                new("200 g", "spaghetti"), new("100 g", "bacon or guanciale, diced"),
                new("2", "egg yolks + 1 whole egg"), new("1/2 cup", "grated parmesan"),
                new("1 tsp", "black pepper"), new("1 cup", "pasta water, reserved")
            },
            Steps = new()
            {
                "Cook spaghetti in salted water until al dente. Reserve some pasta water.",
                "Fry the bacon until crisp, then turn off the heat.",
                "Whisk eggs, parmesan and pepper in a bowl.",
                "Toss hot pasta with bacon, then quickly stir in the egg mixture with splashes of pasta water until creamy."
            }
        },
        new Recipe
        {
            Id = 9, Name = "Fluffy Pancakes", Category = "Breakfast",
            Description = "Thick, soft pancakes perfect with butter and maple syrup.",
            ImageUrl = "images/pancakes.jpg", PrepMinutes = 10, CookMinutes = 15, Servings = 4,
            Tags = new() { "breakfast", "sweet", "egg", "milk", "quick" },
            Ingredients = new()
            {
                new("1.5 cups", "all-purpose flour"), new("3.5 tsp", "baking powder"),
                new("1 tbsp", "sugar"), new("1 cup + 2 tbsp", "milk"),
                new("1", "egg"), new("3 tbsp", "melted butter")
            },
            Steps = new()
            {
                "Whisk flour, baking powder, sugar and a pinch of salt.",
                "Add milk, egg and melted butter and mix until just combined (a few lumps are fine).",
                "Pour 1/4 cup batter onto a lightly oiled pan over medium heat.",
                "Flip when bubbles appear, cook until golden, and serve warm."
            }
        }
    };

    public IReadOnlyList<Recipe> GetAll() => _recipes;

    public Recipe? GetById(int id) => _recipes.FirstOrDefault(r => r.Id == id);

    public IReadOnlyList<string> GetCategories() =>
        _recipes.Select(r => r.Category).Distinct().OrderBy(c => c).ToList();

    /// <summary>
    /// Searches by recipe name, description, category, tags and ingredients.
    /// Every word typed must match something (case-insensitive).
    /// </summary>
    public IReadOnlyList<Recipe> Search(string? query, string? category = null)
    {
        IEnumerable<Recipe> results = _recipes;

        if (!string.IsNullOrWhiteSpace(category))
            results = results.Where(r => r.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(query))
        {
            var words = query.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            results = results.Where(r => words.All(w => Matches(r, w)));
        }

        return results.OrderBy(r => r.Name).ToList();
    }

    private static bool Matches(Recipe r, string word) =>
        Contains(r.Name, word) || Contains(r.Description, word) || Contains(r.Category, word) ||
        r.Tags.Any(t => Contains(t, word)) || r.Ingredients.Any(i => Contains(i.Name, word));

    private static bool Contains(string source, string word) =>
        source.Contains(word, StringComparison.OrdinalIgnoreCase);
}
