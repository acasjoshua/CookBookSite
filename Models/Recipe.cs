namespace ExamProject.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public int PrepMinutes { get; set; }
    public int CookMinutes { get; set; }
    public int Servings { get; set; }

    public List<Ingredient> Ingredients { get; set; } = new();
    public List<string> Steps { get; set; } = new();
    public List<string> Tags { get; set; } = new();

    public int TotalMinutes => PrepMinutes + CookMinutes;
}
