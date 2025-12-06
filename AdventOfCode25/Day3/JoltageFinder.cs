using System.Text;

namespace AdventOfCode25.Day3;

public static class JoltageFinder
{
    public struct Battery(int value, int index)
    {
        public int Value = value;
        public int Index = index;
    }
    
    public static int FindHighestJoltagePart1(string input)
    {
        var highestValue = 0;
        var strList = new List<Battery>();

        for (var i = 0; i < input.Length; i++)
        {
            var number = int.Parse(input[i].ToString());
            strList.Add(new Battery(number, i));
        }

        var orderedList = strList.OrderByDescending(x => x.Value).ToList();

        foreach (var battery1 in orderedList)
        {
            if (battery1.Index == input.Length - 1) continue;

            var highestValue2 = 0;
            
            for (var p = battery1.Index + 1; p < strList.Count; p++)
            {
                var battery2 = strList[p];
                
                if (battery2.Index < battery1.Index) continue;

                if (battery2.Value > highestValue2)
                    highestValue2 = battery2.Value;
            }

            var potValue = (battery1.Value * 10) + highestValue2;

            if (highestValue < potValue)
                highestValue = potValue;
        }
        
        return highestValue;
    }

    public static long FindHighestJoltagePart2(string input)
    {
        long highestValue = 0;
        var strList = new List<Battery>();

        for (var i = 0; i < input.Length; i++)
        {
            var number = int.Parse(input[i].ToString());
            strList.Add(new Battery(number, i));
        }

        var orderedList = strList
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Index)
            .ToList();
        
        foreach (var item in orderedList.Select((value, i) => new { value, i }))
        {
            var battery1 = item.value;
            
            // Cannot start the sequence if 12 digits can't fit
            if (battery1.Index >= input.Length - 12) continue;
            
            var valueString = battery1.Value.ToString();
            var lastUsedBatteryIndex = battery1.Index;

            for (var remainingValues = 11; remainingValues > 0; remainingValues--)
            {
                var nextHighestValue = 0;    
                var finalConsideredIndex = (strList.Count) - (remainingValues);
                
                for (var p = lastUsedBatteryIndex + 1; p <= finalConsideredIndex; p++)
                {
                    var battery2 = strList[p];

                    if (nextHighestValue >= battery2.Value) continue;
                    
                    nextHighestValue = battery2.Value;
                    lastUsedBatteryIndex = p;
                }
                
                valueString += nextHighestValue.ToString();
            }

            var potValue = long.Parse(valueString);

            if (highestValue < potValue)
                highestValue = potValue;
        }
        
        return highestValue;
    }

    
    public static int FindTotalJoltagePart1(string[] lines)
    {
        var totalJoltage = 0;

        foreach (var line in lines)
        {
            totalJoltage += FindHighestJoltagePart1(line);
        }

        return totalJoltage;
    }
    
    public static long FindTotalJoltagePart2(string[] lines)
    {
        return lines.Sum(FindHighestJoltagePart2);
    }
}