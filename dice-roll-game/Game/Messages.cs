namespace DiceRollGame;

public class Messages
{
    public void Start(int tries) => Console.WriteLine($"Dice rolled. Guess what number it shows in {tries} tries.");
    public void Enter() => Console.WriteLine("Enter number: ");
    public void WrongNumber() => Console.WriteLine("Wrong number.");
    public void Win() => Console.WriteLine("You win.\n");
    public void Lose() => Console.WriteLine("You lose.\n");
    public void Incorrect() => Console.WriteLine("Incorrect input.");
}