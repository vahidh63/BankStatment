public class TransactionAnalyzer(List<Transaction> transactions)
{
    private List<Transaction> _transactions;
    public List<Transaction> Transaction { get; set; } = transactions;
    public double ClaCulateTotal()
    {
        double result = Transaction.Sum(p => p.Price);
        return result;
    }
    public double CalTotalInMonth(int month)
    {
        double result = Transaction.Where(i => i.DueDate.Month == month).Sum(p => p.Price);
        return result;
    }
    public double CalTotalByCategury(string categury)
    {
        double result = Transaction.Where(i => i.Categury == categury).Sum(p => p.Price);
        return result;
    }
}