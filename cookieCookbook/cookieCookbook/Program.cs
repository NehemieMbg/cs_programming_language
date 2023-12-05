using System.Text.Json;
using System.Xml;
using cookieCookbook.App;
using cookieCookbook.DataAccess;
using cookieCookbook.DataAccess.FileAccess;
using cookieCookbook.Recipes;
using cookieCookbook.Recipes.Ingredients;

try
{
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
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application experienced an unexpected error" +
                      " and will have to be closed." + $" The error message {ex.Message}");
    Console.WriteLine("Press any key to close.");
    Console.ReadKey();
}