namespace AdventOfCode25.Day1;

public class PuzzleOne(int value, int maximumValue = 99)
{
    public int Value { get; private set;  } = value;

    private readonly char leftSign = 'L';
    private readonly char rightSign = 'R';
    private readonly int _maximumValue = maximumValue;

    public void AddNumber(int number)
    {
        var adjustedValue = AdjustedValue(number);
        var wrappingFix = maximumValue + 1;
        
        Value += adjustedValue;

        if (Value < 0)
        {
            Value += wrappingFix;
        }
        else if (Value > _maximumValue)
        {
            Value -= wrappingFix;
        }
    }

    private int AdjustedValue(int number)
    {
        var originalSign = MathF.Sign(number);
        var actualMovementNumber = number % _maximumValue;
        var timesWrapped = MathF.Abs(number) / _maximumValue;

        if (timesWrapped < 1) return actualMovementNumber;
        
        var wraps = (int)MathF.Round(timesWrapped, 0, MidpointRounding.ToZero);
        if (wraps <= 0) return actualMovementNumber;
        actualMovementNumber += (wraps * -originalSign);

        return actualMovementNumber;
    }

    public int ParseLine(string line)
    {
        var sign = line[0] == leftSign ? -1 : 1;

        if (Int32.TryParse(line[1..], out var number))
        {
            return sign * number;
        }

        return 0;
    }
}