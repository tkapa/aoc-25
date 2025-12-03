using System.Diagnostics;

namespace AdventOfCode25.Day1;

public class SafeCracker(int value, int maximumValue = 99)
{
    public int Value { get; private set;  } = value;
    public int TimesAtZero { get; private set; } = 0;

    private readonly char leftSign = 'L';
    private readonly char rightSign = 'R';
    private readonly int _maximumValue = maximumValue;

    private int TotalNumbers => _maximumValue + 1;

    public void AddNumberPart1(int number)
    {
        Value += number;
        
        Value %= TotalNumbers;

        ClampValue();

        if (Value == 0)
        {
            TimesAtZero++;
        }
    }

    private bool ClampValue()
    {
        var didClamp = false;
        
        if (Value < 0)
        {
            Value += TotalNumbers;
            didClamp = true;
        }
        else if (Value > _maximumValue)
        {
            Value -= TotalNumbers;
            didClamp = true;
        }

        return didClamp;
    }

    public void AddNumberPart2(int number)
    {
        var startingValue = Value;
        var startedAtZero = Value == 0;
        Value += (number % TotalNumbers);
        
        var wraps = (int)MathF.Round((MathF.Abs(number) / TotalNumbers), 0, MidpointRounding.ToZero);
        
        // If the Value == Total Numbers 
        // Result is Value = 0.
        // Wraps will also be 1

        var movedThroughZeroOnCorrection = ClampValue() && !startedAtZero && Value != 0;
        if (movedThroughZeroOnCorrection)
        {
            TimesAtZero++;
        }

        if (Value == 0 && !startedAtZero)
        {
            TimesAtZero++;
        }
        
        if (wraps >= 1)
        {
            TimesAtZero += wraps;
        }

        if (Value < 0 || Value > _maximumValue)
        {
            Debugger.Break();
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