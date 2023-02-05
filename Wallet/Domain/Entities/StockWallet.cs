using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Domain.Entities;

public class StockWallet
{
    public StockWallet(string name)
    {
        Id = Guid.NewGuid();
        Name = name;

        Items = new List<StockWalletItem>();
    }
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public IEnumerable<StockWalletItem> Items { get; private set; }    

    public bool HasStock(int stockId)
    {
        return Items.Any(item => item.StockId == stockId);
    }
    
    public int GetStocksCount(int stockId)
    {
        if (!HasStock(stockId)) return 0;

        return Items.First(x => x.StockId == stockId).Quantity;
    }

    public void ExecuteOperation(Operation operation)
    {
        if (HasStock(operation.StockId)) {
            var item = Items.First(x => x.StockId == operation.StockId);
            item.ExecuteOperation(operation); 
        }
        else
            this.ExecuteOperationOnNewItem(operation);        
    }

    private void ExecuteOperationOnNewItem(Operation operation)
    {
        var newItem = new StockWalletItem(this.Id, operation.StockId, operation.Quantity);
        if (operation.Type.Equals(OperationType.Buy))
            AddNewItem(newItem);
        else
            throw new Exception("Cannot sell an item you don't have.");
    }
    private void AddNewItem(StockWalletItem newItem) 
    {
        Items = Items.Append(newItem).ToList();
    }    
    
}

