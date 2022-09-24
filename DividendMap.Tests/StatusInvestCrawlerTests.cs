using DividendMap.Web.Services.WebCrawler;
using DividendMap.Web.Services.WebCrawler.StatusInvest;

namespace DividendMap.Tests
{
    public class StatusInvestCrawlerTests
    {
        private readonly StatusInvestCrawler _crawler;
        public StatusInvestCrawlerTests()
        {
            _crawler = new StatusInvestCrawler(new WebClient());
        }
        
        [Fact]
        public async Task Should_get_list_of_dividend_payments_by_ticker()
        {
            var ticker = "BRSR6";
            var dividends = await _crawler.GetDividendHistoryByTicker(ticker);

            Assert.True(dividends.Any());
            Assert.All(dividends, (model) =>
            {
                Assert.NotNull(model.Value);
                Assert.NotEmpty(model.InDate);
                Assert.NotEmpty(model.Type);                
            });

        }
    }
}