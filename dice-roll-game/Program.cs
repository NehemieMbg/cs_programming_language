// See https://aka.ms/new-console-template for more information

var dice = new Dice();
var messages = new Messages();
var input = new Input();

messages.Start();

do
{
    input.GetInput();
    Console.WriteLine($"Your input: {input.Number}");
    
    if (dice.Guess(input.Number))
    {
        messages.Win();
        break;
    }
    
    messages.WrongNumber();
    
    if (dice.Guesses >= 3) messages.Lose();

} while (dice.Guesses < 3);



Console.ReadKey();