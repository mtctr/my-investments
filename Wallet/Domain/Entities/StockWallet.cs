namespace Wallet.Domain.Entities;

public class StockWallet
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public IEnumerable<StockWalletItem> Items { get; private set; }
}

