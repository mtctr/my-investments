namespace MyInvestments.Wallet.Domain.Entities;

public class MeanPrice
{
    public MeanPrice(Guid stockWalletId, int stockId, IEnumerable<Operation> operations)
    {
        if (!operations.All(operation => operation.StockId == stockId && operation.WalletId == stockWalletId))
            throw new Exception("All operations should be from the same wallet and stocks");

        StockWalletId = stockWalletId;
        StockId = stockId;
        Date = DateTime.UtcNow;

        Value = CalculateMeanPrice(operations);

    }

    public Guid Id { get; private set; }
    public Guid StockWalletId { get; private set; }
    public int StockId { get; private set; }
    public decimal Value { get; private set; }
    public DateTime Date { get; private set; }

    private decimal CalculateMeanPrice(IEnumerable<Operation> operations)
    {
        return operations.Select(operation => operation.UnitPrice*operation.Quantity).Sum()
                / operations.Select(operation => operation.Quantity).Sum();
    }
}
