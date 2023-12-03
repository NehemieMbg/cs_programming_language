using cookie_cookbook;

public class CookieBook
{
    private string _ingredients = Ingredients.GetIngredients(new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamom(),
        new CocaoPowder()
    });

    public void PrintList() => Console.Write(_ingredients);
}