
public class ExportToHtmal() : IExport
{
    public void Export(List<Transaction> transactions)
    {
        String result = "<!doctype html>";
        result += "<html lang='en'>";
        result += "<head><title>Bank Transaction Report</title></head>";
        result += "<body>";
        result += "<ul>";
        result += "<li><strong>The number of</strong>: " + transactions.Count + "</li>";
        result += "<li><strong>The average is</strong>: " + transactions.Average(p=>p.Price) + "</li>";
        result += "<li><strong>The max is</strong>: " + transactions.Max(p=>p.Price) + "</li>";
        result += "<li><strong>The min is</strong>: " + transactions.Min(p=>p.Price) + "</li>";
        result += "</ul>";
        result += "</body>";
        result += "</html>";
        Console.WriteLine(result);
    }
}
