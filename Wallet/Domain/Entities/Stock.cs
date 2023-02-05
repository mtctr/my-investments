using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Domain.Entities;

public class Stock
{
    public Stock(int companyId, StockType type, DateTime updateDate)
    {
        CompanyId = companyId;
        Type = type;
        UpdateDate = updateDate;
    }

    public int Id { get; private set; }
    public int CompanyId { get; private set; }
    public StockType Type { get; private set; }
    public DateTime UpdateDate { get; private set; }

    public Company Company { get; private set; }

    public IEnumerable<Dividend> Dividends { get; private set; }

    public string GetFullTicker()
    {
        return $"{Company.Ticker}{Type}";
    }
    public decimal LastYearDividends()
    {
        return Dividends
            .Where(dividend => dividend.PayDate.GetValueOrDefault() >= DateTime.Today.AddYears(-1)
                && dividend.PayDate.GetValueOrDefault() <= DateTime.Now)
            .Select(dividend => dividend.Value)
            .Sum();
    }
}
