using AdventOfCode25.Day4;
using AdventOfCode25.Day5;

namespace UnitTests.Day5;

public class IngredientFinderTests
{
    [TestCase("Test.txt", 3)]
    [TestCase("Actual.txt", 733)]
    public void FindValidIds(string fileName, int expectedTotal)
    {
        // Arrange
        var output = 0L;
        
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadAllLines($"./Day5/Inputs/{fileName}");

            var (ranges, ids) = IngredientFinder.ParseInput(lines);
            output = IngredientFinder.FindValidIngredients(ranges, ids);
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        // Assert
        Assert.That(output, Is.EqualTo(expectedTotal)); 
    }
}