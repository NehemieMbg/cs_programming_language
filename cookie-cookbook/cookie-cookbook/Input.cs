public class Input
{
    public void ReadUserInput()
    {
        var isRunning = App.Open;
        do
        {
            var input = Console.ReadLine();
            
            if (input is int) isRunning = App.Close;
            Console.WriteLine(input);
        } while (isRunning == App.Open);
    }
}