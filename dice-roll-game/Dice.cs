namespace DiceRollGame;

public class Dice
{
    public int Number { get; set; } = new Random().Next(1, 7);
    public int Guesses { get; set; } = 0;

    public bool Guess(int number)
    {
        Guesses++;
        return Number == number;
    }
}