namespace AdventOfCode25.Day1;

public class PuzzleOne(int value, int maximumValue = 99)
{
    public int Value { get; private set;  } = value;

    private readonly char leftSign = 'L';
    private readonly char rightSign = 'R';
    private readonly int _maximumValue = maximumValue;

    public void AddNumber(int number)
    {
        var timesWrapped = MathF.Abs(number) / _maximumValue;
        var wraps = (int)MathF.Round(timesWrapped, 0, MidpointRounding.ToZero);
        var wrappingFix = (_maximumValue + 1);

        if (wraps != 0)
        {
            wrappingFix *= wraps;
        }
        
        Value += number;

        if (Value < 0)
        {
            Value += wrappingFix;
        }
        else if (Value > _maximumValue)
        {
            Value -= wrappingFix;
        }
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