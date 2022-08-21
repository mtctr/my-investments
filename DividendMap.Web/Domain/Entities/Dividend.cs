namespace DividendMap.Web.Domain.Entities;

public class Dividend
{
    public int Id { get; private set; }
    public decimal Value { get; private set; }
    public DateTime ExDate { get; private set; }
    public DateTime PayDate { get; private set; }
    public int CompanyId { get; private set; }
    public DividendType Type { get; private set; }
}
public enum DividendType
{
    JCP,
    DIV
}