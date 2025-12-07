namespace AdventOfCode25.Day4;

public static class RollFinder
{
    private static readonly char EmptyIndicator = '.';
    private static readonly char RollIndicator = '@';

    public static int FindValidRolls(bool[][] input)
    {
        var validRolls = 0;
        var xLength = input[0].Length;

        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < xLength; x++)
            {
                if (IsValidRoll(x, y, input)) validRolls++;
            }
        }
        
        return validRolls;
    }
    
    public static int FindValidRollsPart2(bool[][] input)
    {
        var validRolls = 0;
        var xLength = input[0].Length;
        var removalList = new List<(int, int)>();

        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < xLength; x++)
            {
                if (!IsValidRoll(x, y, input)) continue;
                validRolls++;
                removalList.Add((x, y));
            }
        }

        foreach (var (x, y) in removalList)
        {
            input[y][x] = false;
        }
        
        return validRolls;
    }

    public static int FindRecurringValidRolls(bool[][] input)
    {
        var validRolls = 0;
        var newValidRolls = true;

        while (newValidRolls)
        {
            var removedRolls = FindValidRollsPart2(input);
            
            if (removedRolls == 0) newValidRolls = false;
            
            validRolls += removedRolls;
        }

        return validRolls;
    }
    
    public static bool IsValidRoll(int x, int y, bool[][] input)
    {
        if (!input[y][x]) return false;
        
        var xLength = input[0].Length - 1;
        var yLength = input.Length - 1;

        var adjacentRolls = 0;
        
        // Check X - Left
        for (var checkY = y - 1; checkY <= y + 1; checkY++)
        {
            if (checkY < 0 || checkY > yLength) continue;
            
            for (var checkX = x - 1; checkX <= x + 1; checkX++)
            {
                if (checkY == y && checkX == x) continue;
                if (checkX < 0 || checkX > xLength) continue;

                if (input[checkY][checkX]) adjacentRolls++;
            }
        }

        return adjacentRolls < 4;
    }
    
    public static bool[][] RollMatrix(string[] input)
    {
        var rollArr = new bool[input.Length][];

        foreach (var value in input.Select((line, index) => new { line, index }))
        {
            var line = value.line;
            var index = value.index;
            
            var lineArr = new bool[line.Length];

            for (var i = 0; i < line.Length; i++)
            {
                lineArr[i] = line[i] == RollIndicator;
            }
            
            rollArr[index] = lineArr;
        }

        return rollArr;
    }
}