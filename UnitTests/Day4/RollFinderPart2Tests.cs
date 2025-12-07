using AdventOfCode25.Day4;

namespace UnitTests.Day4;

[TestFixture]
public class RollFinderPart2Tests
{
    [TestCase("Test.txt", 0, 0, false)]
    [TestCase("Test.txt", 1, 0, false)]
    [TestCase("Test.txt", 2, 0, true)]
    [TestCase("Test.txt", 3, 0, true)]
    [TestCase("Test.txt", 4, 0, false)]
    [TestCase("Test.txt", 7, 0, false)]
    public void IsValidRollShouldReturnCorrectResult(string fileName, int x, int y, bool expected)
    {
        // Arrange
        var output = !expected;
        
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadAllLines($"./Day4/Inputs/{fileName}");

            var input = RollFinder.RollMatrix(lines);
            // Read the stream as a string.
            output = RollFinder.IsValidRoll(x, y, input);
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        // Assert
        Assert.That(output, Is.EqualTo(expected));  
    }
    
    
    [TestCase("Test.txt", 43)]
    [TestCase("Actual.txt", 8354)]
    public void FindAccessibleRolls(string fileName, int expectedTotal)
    {
        // Arrange
        var output = 0;
        
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadAllLines($"./Day4/Inputs/{fileName}");

            var input = RollFinder.RollMatrix(lines);
            // Read the stream as a string.
            output = RollFinder.FindRecurringValidRolls(input);
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