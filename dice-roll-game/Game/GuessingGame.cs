using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game;

class GuessingGame
{
    private readonly Dice _dice;
    private readonly Messages _messages;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
        _messages = new Messages();
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        _messages.Start(InitialTries);

        var triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("Enter a number:");
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            _messages.WrongNumber();
            --triesLeft;
        }

        return GameResult.Loss;
    }

    public static void PrintResult(GameResult gameResult)
    {
        if (gameResult == GameResult.Victory) new Messages().Win();
        else new Messages().Lose();
    }
}