namespace Wallet.Domain.Entities;

public class StockWalletItem
{
    public int StockWalletId { get; private set; }
    public int StockId { get; private set; }
    public int Quantity { get; private set; }
    public decimal PercentGoal { get; private set; }
}
