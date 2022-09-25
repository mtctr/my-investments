using CsQuery;
using DividendMap.Web.Domain.Ports;
using DividendMap.Web.Services.Adapters.WebCrawler;
using System.Text.Json;
using System.Xml.Linq;

namespace DividendMap.Web.Services.Adapters.WebCrawler.StatusInvest;

public class StatusInvestCrawler : ICrawler<DividendModel>
{
    private readonly WebClient _client;
    private readonly string baseURL = "https://www.statusinvest.com.br/acoes/";

    public StatusInvestCrawler(WebClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<DividendModel>> GetDividendHistoryByTicker(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            throw new Exception("Ticker cannot be empty.");
        if (ticker.Length != 5)
            throw new Exception("Ticker should have 5 characters.");

        var url = $"{baseURL}{ticker}";
        var html = await _client.GetHtml(url);

        return GetDividendsFromHtml(html);
    }

    private IEnumerable<DividendModel> GetDividendsFromHtml(string html)
    {
        var crawlerQuery = CQ.CreateDocument(html);

        var dividendsFieldValue = crawlerQuery["#results"].Val();
        var dividendList = JsonSerializer.Deserialize<IEnumerable<DividendModel>>(dividendsFieldValue);

        return dividendList;
    }
}
