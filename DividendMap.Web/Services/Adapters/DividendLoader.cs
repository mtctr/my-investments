using DividendMap.Web.Domain.Entities;
using DividendMap.Web.Domain.Ports;
using DividendMap.Web.Services.Adapters.WebCrawler.StatusInvest;

namespace DividendMap.Web.Services.Adapters
{
    public class DividendLoader : IDividendLoader
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICrawler<DividendModel> _crawler;

        public DividendLoader(ICompanyRepository companyRepository, ICrawler<DividendModel> crawler)
        {
            _companyRepository = companyRepository;
            _crawler = crawler;
        }

        public async Task UpdateDividends(int companyId)
        {
            var company = await _companyRepository.GetById(companyId);
            var models = await _crawler.GetDividendHistoryByTicker(company.Ticker);
            
            company.ClearPayments();
            
            Parallel.ForEach(
                models,
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                model =>
            {
                var type = model.Type.ToLower().Equals("dividendo") ? DividendType.DIV : DividendType.JCP;
                var dividend = new Dividend(model.Value, GetDateFromString(model.InDate).GetValueOrDefault(), GetDateFromString(model.PayDate),company.Id, type);
                company.AddPayment(dividend);
            });
            
            await _companyRepository.Update(company);
        }

        private DateTime? GetDateFromString(string dateString)
        {
            try
            {
                var format = "dd/MM/yyyy";
                return DateTime.ParseExact(dateString,format,null);
            }
            catch
            {
                return null;
            }
        }
    }
}
