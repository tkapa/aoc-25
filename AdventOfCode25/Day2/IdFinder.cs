namespace AdventOfCode25.Day2;

public class IdFinder
{
    public long TotalValueOfInvalidIds { get; private set; }

    public long FindInvalidIdsInRange(long min, long max)
    {
        var numInvalidIds = 0;
        
        for (var i = min; i <= max; i++)
        {
            var numStr = i.ToString();
            
            if (numStr.Length % 2 != 0) continue;
            
            var halfIndex = numStr.Length / 2;
            var part1 = numStr[..halfIndex];
            var part2 = numStr[halfIndex..];

            if (part1 != part2) continue;
            
            numInvalidIds++;
            TotalValueOfInvalidIds += i;
        }
        
        return numInvalidIds;
    }

    public static List<string> GetInputRanges(string input) => input.Split(',').ToList();
    
    public static (long min, long max) GetIdRange(string input)
    {
        var strArr = input.Split('-');
        var min = long.Parse(strArr[0]);
        var max = long.Parse(strArr[1]);
        
        return (min, max);
    }
}