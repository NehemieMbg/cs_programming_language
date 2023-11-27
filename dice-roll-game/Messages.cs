namespace DiceRollGame;

public class Messages
{
    public void Start() => Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");
    public void Enter() => Console.WriteLine("Enter number: ");
    public void WrongNumber() => Console.WriteLine("Wrong number.");
    public void Win() => Console.WriteLine("You win.\n");
    public void Lose() => Console.WriteLine("You lose.\n");
    public void Incorrect() => Console.WriteLine("Incorrect input.");
}