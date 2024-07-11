public class Transaction
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    public Transaction(DateTime date, decimal amount, string description)
    {
        Date = date;
        Amount = amount;
        Description = description;
    }
}

public class CsvFileReader : IReader
{
    public List<Transaction> ReadTransactions(string filePath)
    {
        var transactions = new List<Transaction>();

        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var columns = line.Split(',');
                var date = DateTime.ParseExact(columns[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var amount = decimal.Parse(columns[1]);
                var description = columns[2];
                transactions.Add(new Transaction(date, amount, description));
            }
        }

        return transactions;
    }
}

public class BankTransactionAnalyzer
{
    private readonly List<Transaction> _transactions;

    public BankTransactionAnalyzer(List<Transaction> transactions)
    {
        _transactions = transactions;
    }

    public decimal CalculateTotalAmount()
    {
        return _transactions.Sum(t => t.Amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the CSV file path as a command-line argument.");
            return;
        }

        string filePath = args[0];
        var csvReader = new CsvFileReader();
        var transactions = csvReader.ReadTransactions(filePath);

        var analyzer = new BankTransactionAnalyzer(transactions);
        decimal totalAmount = analyzer.CalculateTotalAmount();

        Console.WriteLine($"The total for all transactions is {totalAmount:C}");
    }
}