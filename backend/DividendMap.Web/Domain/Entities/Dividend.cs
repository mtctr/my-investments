namespace DividendMap.Web.Domain.Entities;

public class Dividend
{
    private Dividend() { }
    public Dividend(decimal value, DateTime inDate, DateTime? payDate, int companyId, DividendType type)
    {
        Value = value;
        InDate = inDate;
        PayDate = payDate;
        CompanyId = companyId;
        Type = type;
    }

    public int Id { get; private set; }
    public decimal Value { get; private set; }
    public DateTime InDate { get; private set; }
    public DateTime? PayDate { get; private set; }
    public int CompanyId { get; private set; }
    public DividendType Type { get; private set; }

    public Company Company { get; private set; }
}
public enum DividendType
{
    JCP,
    DIV
}