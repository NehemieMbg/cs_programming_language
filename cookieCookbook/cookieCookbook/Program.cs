using System.Text.Json;
using System.Xml;
using cookieCookbook.App;
using cookieCookbook.DataAccess;
using cookieCookbook.DataAccess.FileAccess;
using cookieCookbook.Recipes;
using cookieCookbook.Recipes.Ingredients;
using IRecipesRepository = cookieCookbook.Recipes.IRecipesRepository;

const FileFormat Format = FileFormat.Json;

var ingredientsRegister = new IngredientsRegister();
IStringsRepository stringsRepository = (Format == FileFormat.Json)
    ? new StringsTextualRepository()
    : new StringsJsonRepository();
const string FileName = "recipe";
var fileMetaData = new FileMetaData(FileName, Format);

// RecipesRepository
var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister
    ),
    new RecipesConsoleUserInteraction(
        ingredientsRegister
    ));

cookiesRecipesApp.Run(fileMetaData.ToPath);

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

