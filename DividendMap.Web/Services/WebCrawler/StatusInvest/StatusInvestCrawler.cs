using CsQuery;
using System.Text.Json;
using System.Xml.Linq;

namespace DividendMap.Web.Services.WebCrawler.StatusInvest;

public class StatusInvestCrawler
{
    private readonly WebClient _client;
    private readonly string baseURL = "https://www.statusinvest.com.br/acoes/";
    
    public StatusInvestCrawler(WebClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<DividendModel>> GetDividendHistoryByTicker(string ticker)
    {
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
