using System.Text.Json.Serialization;

namespace DividendMap.Web.Services.WebCrawler.StatusInvest
{
    public class DividendModel
    {   
        [JsonPropertyName("et")]
        public string Type { get; set; }
        [JsonPropertyName("ed")]
        public string InDate { get; set; }
        [JsonPropertyName("pd")]
        public string PayDate { get; set; }
        [JsonPropertyName("v")]
        public decimal Value { get; set; }
    }
}
