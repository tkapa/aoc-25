using AdventOfCode25.Day1;

namespace UnitTests.Day1;

[TestFixture]
public class PuzzleTwoTests
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
    public void AddNumberPart2ShouldReturnCorrectNumber(int startingValue, int addedValue, int finalValue)
    {
        // Arrange
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        
        // Act
        safe.AddNumberPart2(addedValue);
        
        // Assert
        Assert.That(safe.Value, Is.EqualTo(finalValue));
    }
    
        
    [TestCase(11, "R8", 19)]
    [TestCase(19, "L19", 0)]
    [TestCase(0, "L1", 99)]
    [TestCase(99, "R1", 0)]
    [TestCase(5, "L10", 95)]
    [TestCase(95, "R5", 0)]
    [TestCase(16, "R284", 0)]
    public void ParsedLinePart2WhenAddedShouldReturnCorrectNumber(int startingValue, string input, int expectedValue)
    {
        // Arrange
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        
        // Act
        var addedNumber = safe.ParseLine(input);
        safe.AddNumberPart1(addedNumber);
        
        // Assert
        Assert.That(safe.Value, Is.EqualTo(expectedValue));
    }
    
    [TestCase(50, -68, 82, 1)]
    [TestCase(82, -30, 52, 0)]
    [TestCase(52, 48, 0, 1)]
    [TestCase(0, -5, 95, 0)]
    [TestCase(95, 60, 55, 1)]
    [TestCase(55, -55, 0, 1)]
    [TestCase(0, -1, 99, 0)]
    [TestCase(99, -99, 0, 1)]
    [TestCase(0, 14, 14, 0)]
    [TestCase(14, -82, 32, 1)]
    [TestCase(99, -198, 1, 1)]
    [TestCase(99, -200, 99, 2)]
    [TestCase(99, 200, 99, 2)]
    [TestCase(99, 198, 97, 2)]
    [TestCase(0, 100, 0, 1)]
    [TestCase(0, 1000, 0, 10)]    
    [TestCase(0, -100, 0, 1)]
    [TestCase(0, -1000, 0, 10)]
    [TestCase(50, -1000, 50, 10)]
    [TestCase(50, -950, 0, 10)]
    [TestCase(50, -50, 0, 1)]
    [TestCase(50, -150, 0, 2)]
    [TestCase(50, 150, 0, 2)]
    [TestCase(30, -30, 0, 1)]
    [TestCase(30, -130, 0, 2)]
    public void AddNumberPart2ShouldGiveCorrectTimesAtZero(int startingValue, int addedValue, int finalValue,
        int timesAtZero)
    {
        // Arrange
        var safe = new PuzzleOne(startingValue, _defaultMaximumValue);
        
        // Act
        safe.AddNumberPart2(addedValue);
        
        // Assert
        Assert.That(safe.Value, Is.EqualTo(finalValue));
        Assert.That(safe.TimesAtZero, Is.EqualTo(timesAtZero));
    }
    
    [TestCase("Test1.txt", 6)]
    [TestCase("Actual1.txt", 0)]
    public void PartTwoVerification(string fileName, int expectedTimes)
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
                safe.AddNumberPart2(addedNumber);
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