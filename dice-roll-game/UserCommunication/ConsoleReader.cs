namespace DiceRollGame.UserCommunication;

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            new Messages().Enter();
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}