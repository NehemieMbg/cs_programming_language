public class Logger
{
    private readonly string _logFileNmae;

    public Logger(string logFileNmae)
    {
        _logFileNmae = logFileNmae;
    }

    public void Log(Exception ex)
    {
        var entry = $@"[{DateTime.Now}]
Exception message: {ex.Message}
Stack trace: {ex.StackTrace}


";

        File.AppendAllText(_logFileNmae, entry);
    }
}