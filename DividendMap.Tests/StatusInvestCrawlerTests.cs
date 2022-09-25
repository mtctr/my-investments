using DividendMap.Web.Services.Adapters.WebCrawler.StatusInvest;
using DividendMap.Web.Services.WebCrawler;

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
        public async Task Get_list_of_dividend_payments_by_ticker_if_is_valid()
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

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        public async Task Should_throw_exception_if_ticker_is_empty_or_whitespace(string ticker)
        {
            await Assert.ThrowsAsync<Exception>(async() => await _crawler.GetDividendHistoryByTicker(ticker));
        }
        
        [Theory]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("ABC")]
        [InlineData("ABCB")]
        [InlineData("ABCBC4")]
        public async Task Should_throw_exception_if_ticker_does_not_have_5_characters(string ticker)
        {
            await Assert.ThrowsAsync<Exception>(async () => await _crawler.GetDividendHistoryByTicker(ticker));
        }
    }
}