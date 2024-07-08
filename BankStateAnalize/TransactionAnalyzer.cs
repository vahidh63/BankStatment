public class TransactionAnalyzer(List<Transaction> transactions)
{
    private List<Transaction> _transactions;
    public List<Transaction> Transaction { get; set; } = transactions;
    public double ClaCulateTotal()
    {
        double total = 0;
        foreach (var item in Transaction)
        {
            total += item.Price;
        }
        return total;
    }
    public double CalTotalInMonth(int month)
    {
        double total = 0;
        foreach (var item in Transaction)
        {
            if (item.DueDate.Month == month)
                total += item.Price;
        }
        return total;
    }
    public double CalTotalByCategury(string categury)
    {
        double total = 0;
        foreach (var item in Transaction)
        {
            if (item.Categury == categury)
                total += item.Price;
        }
        return total;
    }
}