namespace DividendMap.Web.Domain.Entities;

public class Company
{
    private Company() {}

    public Company(string name, string stockName)
    {
        Name = name;
        StockName = stockName;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string StockName { get; private set; }
    public IList<Dividend> DividendHistory { get; private set; } = new List<Dividend>();

    public void ChangeName(string newName)
    {
        Name = newName;
    }
    public void ChangeStockName(string newStockName)
    {
        StockName = newStockName;
    }
    public void AddPayment(Dividend dividend)
    {
        DividendHistory.Add(dividend);
    }

}
