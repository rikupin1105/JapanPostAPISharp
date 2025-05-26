using System.Text.Json.Serialization;

namespace JPZipSharp.Model
{
    public class SearchCodeResponce
    {
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }
        [JsonPropertyName("searchtype")]
        public string Searchtype { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
    }

}
