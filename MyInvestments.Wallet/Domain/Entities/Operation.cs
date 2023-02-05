using MyInvestments.Wallet.Domain.Enums;

namespace MyInvestments.Wallet.Domain.Entities;

public class Operation
{
    public Operation(Guid walletId, int stockId, int quantity, decimal unitPrice, OperationType type, DateTime date)
    {
        if(unitPrice <= 0)
            throw new Exception("Unit Price cannot be less than zero.");
        if(quantity <= 0)        
            throw new Exception("Quantity cannot be less than zero.");

        WalletId = walletId;
        StockId = stockId;
        Quantity = quantity;        
        UnitPrice = unitPrice;
        Type = type;
        Date = date;
    }

    public Guid Id { get; private set; }
    public Guid WalletId { get; private set; }
    public int StockId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public OperationType Type { get; private set; }
    public DateTime Date { get; private set; }

    public Stock Stock { get; private set; }
    public StockWallet Wallet { get; private set; }
}
