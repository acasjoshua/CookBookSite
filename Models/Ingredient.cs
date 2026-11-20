using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ExamProject.Models;

// Ingredient <-> public.recipe_ingredients
[Table("recipe_ingredients")]
public class Ingredient : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("recipe_id")]               // foreign key -> recipes.id
    public int RecipeId { get; set; }

    [Column("quantity")]
    public string Quantity { get; set; } = string.Empty;

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    public Ingredient() { }

    public Ingredient(string quantity, string name)
    {
        Quantity = quantity;
        Name = name;
    }
}