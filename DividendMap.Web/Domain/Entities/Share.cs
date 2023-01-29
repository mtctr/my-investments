namespace DividendMap.Web.Domain.Entities
{
    public enum ShareType
    {
        ON = 3,
        PN,
        PNA,
        PNB,
        UNIT=11
    }
    public class Share
    {
        public int Id { get; private set; }        
        public ShareType Type { get; private set; }
        public decimal LastPrice { get;private set; }
        public decimal Last12MonthsTotalPayments { get;private set; }

        public Company Company { get; private set; }

        public string GetFullTicker()
        {
            return $"{Company.Ticker}{Type}";
        }

    }
}
