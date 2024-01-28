public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGamesDeserializer _desierializeVideoGames;
    private readonly IFileReader _fileReader;

    public GameDataParserApp(IUserInteractor userInteractor, IGamesPrinter gamesPrinter,
        IVideoGamesDeserializer desierializeVideoGames, IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _desierializeVideoGames = desierializeVideoGames;
        _fileReader = fileReader;
    }

    public void Run()
    {
        var fileName = _userInteractor.ReadValidFilePath();
        var fileContents = _fileReader.Read(fileName);
        var videoGames = _desierializeVideoGames.DeserializeFrom(fileContents, fileName);
        _gamesPrinter.Print(videoGames);
    }
}