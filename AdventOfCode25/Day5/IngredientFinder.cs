namespace AdventOfCode25.Day5;

public static class IngredientFinder
{
    public static long FindValidIngredients(List<(long, long)> idRanges, List<long> ids)
    {
        return ids.Count(idRanges.IsWithinAnyRange);
    }

    public static (List<(long, long)>, List<long>) ParseInput(string[] input)
    {
        var splitIdx = input.IndexOf(string.Empty);
        
        var ranges = input[..splitIdx];
        var ids = input[(splitIdx + 1)..];
        
        var parsedRanges = new List<(long, long)>();
        var parsedIds = new List<long>();

        parsedIds.AddRange(ids.Select(long.Parse));

        parsedRanges.AddRange(ranges.Select(x =>
        {
            var strArr = x.Split('-');
            return (long.Parse(strArr[0]), long.Parse(strArr[1]));
        }));
        
        return (parsedRanges, parsedIds);
    }

    public static bool IsWithinAnyRange(this List<(long, long)> idRanges, long id)
    {
        var isInARange = false;
        
        foreach (var (min, max) in idRanges)
        {
            if (id < min || id > max) continue;
            isInARange = true;
            break;
        }
        
        return isInARange;
    }
}