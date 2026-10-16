namespace ExamProject.Models;

public class Ingredient
{
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;

    public Ingredient() { }

    public Ingredient(string quantity, string name)
    {
        Quantity = quantity;
        Name = name;
    }
}
