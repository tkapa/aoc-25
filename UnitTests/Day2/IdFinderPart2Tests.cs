using AdventOfCode25.Day2;

namespace UnitTests.DayTwo;

[TestFixture]
public class IdFinderPart2Tests
{
    [TestCase(11, 22, 2)]
    [TestCase(95, 115, 2)]
    [TestCase(1188511880, 1188511890, 1)]
    [TestCase(222220, 222224, 1)]
    [TestCase(1698522, 1698528, 0)]
    [TestCase(824824821, 824824827, 1)]
    public void FindInvalidIdsInRangeReturnsSuccess(int min, int max, int expectedValue)
    {
        // Arrange
        var idParser = new IdFinder(false);

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

    [TestCase("1111", false)]
    [TestCase("12", true)]
    [TestCase("824824821", true)]
    [TestCase("824824824", false)]
    public void IsValidIdPart2ReturnsCorrectValue(string input, bool expectedValue)
    {
        // Act
        var isValid = IdFinder.IsValidIdPart2(input);
        
        //Assert
        Assert.That(isValid, Is.EqualTo(expectedValue));
    }
    
        
    [TestCase("Test.txt", 4174379265)]
    [TestCase("Actual.txt", 24043483400)]
    public void FindInvalidIdsFindsTotalValueOfIds(string fileName, long expectedTotal)
    {
        // Arrange
        var idParser = new IdFinder(false);
        
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