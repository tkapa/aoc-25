using AdventOfCode25.Day2;

namespace UnitTests.DayTwo;

[TestFixture]
public class IdFinderTests
{
    [TestCase(11, 22, 2)]
    [TestCase(95, 115, 1)]
    [TestCase(1188511880, 1188511890, 1)]
    [TestCase(222220, 222224, 1)]
    public void FindInvalidIdsInRangeReturnsSuccess(int min, int max, int expectedValue)
    {
        // Arrange
        var idParser = new IdFinder();

        // Act
        var output = idParser.FindInvalidIdsInRange(min, max);

        // Assert
        Assert.That(output, Is.EqualTo(expectedValue)); 
    }
    
    [TestCase("11-22", 11, 22)]
    [TestCase("95-115", 95, 115)]
    public void GetIdRangeGetsMinMaxValues(string input, int expectedMin, int expectedMax)
    {
        // Arrange
        // Act
        var (min, max) = IdFinder.GetIdRange(input);

        // Assert
        Assert.That(min, Is.EqualTo(expectedMin));
        Assert.That(max, Is.EqualTo(expectedMax));
    }
    
        
    [TestCase("Test.txt", 1227775554)]
    [TestCase("Actual.txt", 24043483400)]
    public void FindInvalidIdsFindsTotalValueOfIds(string fileName, long expectedTotal)
    {
        // Arrange
        var idParser = new IdFinder();
        
        try
        {
            // Open the text file using a stream reader.
            var rawIdText = File.ReadAllText($"./Day2/Inputs/{fileName}");
            var rawIdRanges = IdFinder.GetInputRanges(rawIdText);

            // Read the stream as a string.
            foreach (var line in rawIdRanges)
            {
                var (min, max) = IdFinder.GetIdRange(line);
                idParser.FindInvalidIdsInRange(min, max);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        // Assert
        Assert.That(idParser.TotalValueOfInvalidIds, Is.EqualTo(expectedTotal)); 
    }
}