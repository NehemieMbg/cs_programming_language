namespace DiceRollGame;

public class Input
{
    public int Number { get; set; }

    public void GetInput()
    {
        var validInput = false;
        
        do
        {
            new Messages().Enter();
            validInput = new Validate().Input(Console.ReadLine()!, out int parsedInput);
            Number = parsedInput;
            
            if (!validInput) new Messages().Incorrect();
        } while (!validInput);
    }
}