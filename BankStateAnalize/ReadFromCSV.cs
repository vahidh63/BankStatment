
using System.Globalization;
public class ReadFromCSV(string filePath) : IReader
{
    private readonly string _filePath;
    public string FilePath { get; set; } = filePath;
    public Transaction TransactionParser(string line)
    {
        string[] query = line.Split(',');
        Transaction result = new Transaction(DateTime.ParseExact(query[0], "dd/MM/yyyy", CultureInfo.InvariantCulture), int.Parse(query[1]), query[2]);
        return result;
    }
    public List<Transaction> FileLoad()
    {
        try
        {
            List<Transaction> result = new List<Transaction>();
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("File not found.");
                return result;
            }
            // Read the file line by line
            using (var reader = new StreamReader(FilePath))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(TransactionParser(line));
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}