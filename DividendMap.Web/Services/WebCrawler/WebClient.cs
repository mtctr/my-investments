using System.Text;

namespace DividendMap.Web.Services.WebCrawler;

    public class WebClient
    {
        public HttpClient HttpClientBase;
        public WebClient()
        {
            HttpClientBase = new HttpClient();
        }
        public async Task<string> GetHtml(string url)
        {
            var response = await HttpClientBase.GetByteArrayAsync(url);
            return Encoding.GetEncoding("ISO-8859-1").GetString(response, 0, response.Length - 1);
        }
    }
