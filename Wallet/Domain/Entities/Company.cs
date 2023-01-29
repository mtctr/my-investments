namespace Wallet.Domain.Entities;

public class Company
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Ticker { get; private set; }

    public int IndustryTypeId { get; private set; }
    public IndustryType IndustryType { get; private set; }
}
