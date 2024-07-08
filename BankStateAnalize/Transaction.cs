public class Transaction(DateTime duedate, int price, string categury)
{
    private readonly DateTime _dueDate ;
    private readonly int _price ;
    private readonly string _categury ;

    public DateTime DueDate { get; set; } = duedate;
    public int Price { get; set; } = price;
    public string Categury { get; set; } = categury;
    public override string ToString()
    {
        return $"Transaction Date= {_dueDate}, amount= {_price}, About={_categury}";
    }

}