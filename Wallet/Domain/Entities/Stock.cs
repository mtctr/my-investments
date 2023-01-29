using Wallet.Domain.Enums;

namespace Wallet.Domain.Entities;

public class Stock
{
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
        return this.Dividends
            .Where(dividend => dividend.PayDate.GetValueOrDefault() >= DateTime.Today.AddYears(-1)
                && dividend.PayDate.GetValueOrDefault() <= DateTime.Now)
            .Select(dividend => dividend.Value)
            .Sum();
    }
}
