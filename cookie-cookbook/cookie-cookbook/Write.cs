using cookie_cookbook;

public static class Write
{
    public static void WriteToTXT(List<Ingredient> recipe)
    {
        var content = new Recipes().PrintRecipe(recipe);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Recipes.txt");
        File.WriteAllText(filePath, content);
    }
}