using System.Text.Json.Serialization;

namespace JapanPostAPISharp.Model
{
    public class AddressZipResponse
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("addresses")]
        public AddressArray[]? Addresses { get; set; }
    }


}
