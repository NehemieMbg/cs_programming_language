namespace cookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id) return ingredient;
        }

        return null;
    }
}

public abstract class Ingredient
{
    
    public abstract int Id { get; }
    public abstract string Name { get; }

    public virtual string PreparationInstructions =>
        "Add to other ingredients.";

    public override string ToString() =>
        $"{Id}. {Name}";
}