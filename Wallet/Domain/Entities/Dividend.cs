using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Domain.Entities;

public class Dividend
{
    public int Id { get; private set; }
    public int StockId { get; private set; }
    public DateTime InDate { get; private set; }
    public DateTime? PayDate { get; private set; }
    public DividendType Type { get; private set; }
    public decimal Value { get; private set; }

}
