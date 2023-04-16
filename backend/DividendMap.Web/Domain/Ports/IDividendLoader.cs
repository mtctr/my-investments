namespace DividendMap.Web.Domain.Ports
{
    public interface IDividendLoader
    {
        Task UpdateDividends(int companyId);
    }
}
