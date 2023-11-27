namespace DiceRollGame;

public class Validate
{
    public bool Input(string input, out int parsedInput)
    {
        return int.TryParse(input, out parsedInput);
    }
}