
using System.Globalization;
using CsvHelper;

var filePath = "../Test.csv";
int total = 0;

ReadFromCSV reader=new ReadFromCSV(filePath);
List<Transaction> result = reader.FileLoad();
TransactionAnalyzer transactionAnalyzer = new TransactionAnalyzer(result);
Summary(transactionAnalyzer);




static void Summary(TransactionAnalyzer result)
{
Console.WriteLine($"Total: {result.ClaCulateTotal()}");
Console.WriteLine($"Total in month {1}: {result.CalTotalInMonth(1)}");
Console.WriteLine($"Total by Categury: {result.CalTotalByCategury("Tesco")}");
}

