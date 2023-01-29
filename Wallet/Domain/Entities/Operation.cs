using Wallet.Domain.Enums;

namespace Wallet.Domain.Entities;

public class Operation
{
    public Guid Id { get; private set; }
    public int WalletId { get; private set; }
    public int StockId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public OperationType Type { get; private set; } 
    public DateTime Date { get; private set; }

    public Stock Stock { get; private set; }
    public StockWallet Wallet { get; private set; }
}
