using AdventOfCode25.Day3;

namespace UnitTests.Day3;

[TestFixture]
public class JoltageFinderTests
{
    [TestCase("987654321111111", 98)]
    [TestCase("811111111111119", 89)]
    [TestCase("234234234234278", 78)]
    [TestCase("818181911112111", 92)]
    public void FindHighestJoltage(string input, int expectedValue)
    {
        // Act
        var output = JoltageFinder.FindHighestJoltagePart1(input);
        
        // Assert
        Assert.That(output, Is.EqualTo(expectedValue));
    }
    
    [TestCase("Test.txt", 17346)]
    [TestCase("Actual.txt", 38262920235)]
    public void FindTotalHighestJoltage(string fileName, long expectedTotal)
    {
        // Arrange
        var output = 0;
        
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadAllLines($"./Day3/Inputs/{fileName}");
    
            // Read the stream as a string.
            output = JoltageFinder.FindTotalJoltagePart1(lines);
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