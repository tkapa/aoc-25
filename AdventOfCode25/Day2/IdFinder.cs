using System.Runtime.InteropServices.Marshalling;

namespace AdventOfCode25.Day2;

public class IdFinder(bool isPart1 = true)
{
    public long TotalValueOfInvalidIds { get; private set; }

    public long FindInvalidIdsInRange(long min, long max)
    {
        var numInvalidIds = 0;
        
        for (var i = min; i <= max; i++)
        {
            var numStr = i.ToString();

            if (isPart1)
            {
                if (IsValidIdPart1(numStr)) continue;
            }
            else
            {
                if (IsValidIdPart2(numStr)) continue;
            }
            
            numInvalidIds++;
            TotalValueOfInvalidIds += i;
        }
        
        return numInvalidIds;
    }

    public static bool IsValidIdPart1(string numStr)
    {
        if (numStr.Length % 2 != 0) return true;
            
        var halfIndex = numStr.Length / 2;
        var part1 = numStr[..halfIndex];
        var part2 = numStr[halfIndex..];

        return part1 != part2;
    }
    
    public static bool IsValidIdPart2(string numStr)
    {
        var isValid = true;
        var halfStringLength = numStr.Length / 2;

        for (var i = 0; i < halfStringLength; i++)
        {
            var partLen = i + 1;
            if (numStr.Length % partLen != 0) continue;
            
            var compareValue = numStr[..partLen];

            var strParts = numStr.Split(compareValue);
            
            if (strParts.Any(x => !string.IsNullOrEmpty(x))) continue;
            isValid = false;
        }
        
        return isValid;
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