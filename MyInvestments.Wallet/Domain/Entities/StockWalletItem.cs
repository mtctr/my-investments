using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Domain.Entities;

public class StockWalletItem
{
    public StockWalletItem(Guid stockWalletId, int stockId, int quantity, decimal percentGoal = 0)
    {
        StockWalletId = stockWalletId;
        StockId = stockId;
        Quantity = quantity;
        PercentGoal = percentGoal;
    }

    public Guid StockWalletId { get; private set; }
    public int StockId { get; private set; }
    public int Quantity { get; private set; }
    public decimal PercentGoal { get; private set; }


    public void ExecuteOperation(Operation operation)
    {
        if (operation.Type.Equals(OperationType.Buy))
            this.ExecuteBuy(operation);
        else if (operation.Type.Equals(OperationType.Sell))
            this.ExecuteSell(operation);
    }
    private void ExecuteBuy(Operation operation)
    {
        UpdateQuantity(this.Quantity + operation.Quantity);
    }

    private void ExecuteSell(Operation operation)
    {
        if (this.Quantity == 0)
            throw new Exception("Cannot sell items when you have none.");

        if (operation.Quantity > this.Quantity)
            throw new Exception("Cannot sell more items than you have.");

        UpdateQuantity(this.Quantity - operation.Quantity);
    }
    private void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
