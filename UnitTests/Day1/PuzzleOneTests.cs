using System.Xml.Linq;
using AdventOfCode25.Day1;

namespace UnitTests.Day1;

public class PuzzleOneTests
{
    private readonly int _defaultMaximumValue = 99;
    
    [TestCase(0, 1, 1)]
    [TestCase(99, 1, 0)]
    [TestCase(1, -1, 0)]
    [TestCase(80, 99, 79)]
    [TestCase(80, 100, 80)]
    [TestCase(80, 198, 78)]
    [TestCase(80, -99, 81)]
    [TestCase(80, -198, 82)]
    [TestCase(90, -100, 90)]
    [TestCase(50, -68, 82)]
    [TestCase(82, -30, 52)]
    [TestCase(52, 48, 0)]
    [TestCase(0, -5, 95)]
    [TestCase(95, 60, 55)]
    [TestCase(55, -55, 0)]
    [TestCase(0, -1, 99)]
    [TestCase(99, -99, 0)]
    [TestCase(0, 14, 14)]
    [TestCase(14, -82, 32)]
    public void AddNumberPart1ShouldReturnCorrectNumber(int startingValue, int addedValue, int finalValue)
    {
        // Arrange
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        
        // Act
        safe.AddNumberPart1(addedValue);
        
        // Assert
        Assert.That(safe.Value, Is.EqualTo(finalValue));
    }

    [TestCase("L1", -1)]
    [TestCase("R1", 1)]
    [TestCase("R200", 200)]
    [TestCase("L200", -200)]
    public void ParseLineShouldReturnCorrectNumber(string input, int expectedValue)
    {
        // Arrange
        var safe = new PuzzleOne(0, _defaultMaximumValue);
        
        // Act
        var output = safe.ParseLine(input);
        
        // Assert
        Assert.That(output, Is.EqualTo(expectedValue));
    }

    [TestCase(11, "R8", 19)]
    [TestCase(19, "L19", 0)]
    [TestCase(0, "L1", 99)]
    [TestCase(99, "R1", 0)]
    [TestCase(5, "L10", 95)]
    [TestCase(95, "R5", 0)]
    [TestCase(16, "R284", 0)]
    public void ParsedLinePart1WhenAddedShouldReturnCorrectNumber(int startingValue, string input, int expectedValue)
    {
        // Arrange
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        
        // Act
        var addedNumber = safe.ParseLine(input);
        safe.AddNumberPart1(addedNumber);
        
        // Assert
        Assert.That(safe.Value, Is.EqualTo(expectedValue));
    }

    [TestCase("Test1.txt", 3)]
    [TestCase("Actual1.txt", 1141)]
    public void PartOneVerification(string fileName, int expectedTimes)
    {
        var startingValue = 50;
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        try
        {
            // Open the text file using a stream reader.
            var lines = File.ReadLines($"./DayOne/Inputs/{fileName}");

            // Read the stream as a string.
            foreach (var line in lines)
            {
                var addedNumber = safe.ParseLine(line);
                safe.AddNumberPart1(addedNumber);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        Assert.That(safe.TimesAtZero, Is.EqualTo(expectedTimes));
    }
}