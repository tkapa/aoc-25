using AdventOfCode25.Day3;

namespace UnitTests.Day3;

[TestFixture]
public class JoltageFinderPart2Tests
{
    [TestCase("987654321111111", 987654321111)]
    [TestCase("811111111111119", 811111111119)]
    [TestCase("234234234234278", 434234234278)]
    [TestCase("818181911112111", 888911112111)]
    public void FindHighestJoltage(string input, long expectedValue)
    {
        // Act
        var output = JoltageFinder.FindHighestJoltagePart2(input);
        
        // Assert
        Assert.That(output, Is.EqualTo(expectedValue));
    }
    
    [TestCase("Test.txt", 3121910778619)]
    [TestCase("Actual.txt", 38262920235)]
    public void FindInvalidIdsFindsTotalValueOfIds(string fileName, long expectedTotal)
    {
        // Arrange
        long output = 0;
        
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadAllLines($"./Day3/Inputs/{fileName}");
    
            // Read the stream as a string.
            output = JoltageFinder.FindTotalJoltagePart2(lines);
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