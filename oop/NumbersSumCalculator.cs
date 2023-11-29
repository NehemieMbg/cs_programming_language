namespace oop;

var numbers = new List<int> { 1, 4, 6, -1, 12, 44, -8, -19 };

public class NumbersSumCalculator
{
    public int Calculate(List<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}