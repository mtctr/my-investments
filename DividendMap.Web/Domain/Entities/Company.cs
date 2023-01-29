using System.Globalization;

namespace DividendMap.Web.Domain.Entities;

public class Company
{
    private Company() {}

    public Company(string name, string ticker)
    {
        Name = name;
        Ticker = ticker;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Ticker { get; private set; }
    public IList<Dividend> DividendHistory { get; private set; } = new List<Dividend>();

    public void ChangeName(string newName)
    {
        Name = newName;
    }
    public void ChangeStockName(string newStockName)
    {
        Ticker = newStockName;
    }
    public void ClearPayments()
    {
        DividendHistory.Clear();
    }
    public void AddPayment(Dividend dividend)
    {
        DividendHistory.Add(dividend);
    }
    public IEnumerable<object> DividendsByMonth()
    {
        var dateTimeFormatInfo = new DateTimeFormatInfo();

        return DividendHistory
            .GroupBy(x => x.InDate.Month)
            .OrderBy(x => x.Key)
            .Select(x => new object[2]{ dateTimeFormatInfo.GetAbbreviatedMonthName(x.Key), x.Count()})
            .ToList();
    }

}
