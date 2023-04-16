namespace DividendMap.Web.Domain.Ports
{
    public interface ICrawler<T>
    {
        Task<IEnumerable<T>> GetDividendHistoryByTicker(string ticker);
    }
}
