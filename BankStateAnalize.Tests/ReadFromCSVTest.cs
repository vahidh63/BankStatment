public class ReadFromCSVTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShouldParseOneCorrectLine()
    {
        string line = "30/01/2017,-50,Tesco";
        var result = new ReadFromCSV("").TransactionParser(line);
        var expected = new Transaction(DateTime.Parse("2017, JANUARY, 30"), -50, "Tesco");
        double tolerance = 0.0d;
        Assert.AreEqual(expected.DueDate, result.DueDate);
        Assert.AreEqual(expected.Price, result.Price, tolerance);
        Assert.AreEqual(expected.Categury, result.Categury);
    }
}