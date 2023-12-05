using cookieCookbook.App;
using cookieCookbook.Recipes;
using IRecipesRepository = cookieCookbook.Recipes.IRecipesRepository;

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(
        RecipesRepository recipesRepository,
        IRecipesUserInteraction recipesUserInteraction
    )
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        // Reading all the recipes
        var allRecipes = _recipesRepository.Read(filePath);
        // Printing all existing recipes
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        // Prompt the user to create recipe
        _recipesUserInteraction.PromptToCreateRecipe();
        // // Reading ingredients from the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe added:");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. Recipe will not be saved.");
        }

        _recipesUserInteraction.Exit();
    }
}