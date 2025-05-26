using System.Text.Json.Serialization;

namespace JapanPostAPISharp.Model
{
    public class AddressArray
    {
        [JsonPropertyName("dgacode")]
        public string? DgaCode { get; set; }

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("pref_code")]
        public string? PrefCode { get; set; }

        [JsonPropertyName("pref_name")]
        public string? PrefName { get; set; }

        [JsonPropertyName("pref_kana")]
        public string? PrefKana { get; set; }

        [JsonPropertyName("pref_roma")]
        public string? PrefRoma { get; set; }

        [JsonPropertyName("city_code")]
        public string? CityCode { get; set; }

        [JsonPropertyName("city_name")]
        public string? CityName { get; set; }

        [JsonPropertyName("city_kana")]
        public string? CityKana { get; set; }

        [JsonPropertyName("city_roma")]
        public string? CityRoma { get; set; }

        [JsonPropertyName("town_name")]
        public string? TownName { get; set; }

        [JsonPropertyName("town_kana")]
        public string? TownKana { get; set; }

        [JsonPropertyName("town_roma")]
        public string? TownRoma { get; set; }

        [JsonPropertyName("biz_name")]
        public string? BizName { get; set; }

        [JsonPropertyName("biz_kana")]
        public string? BizKana { get; set; }

        [JsonPropertyName("biz_roma")]
        public string? BizRoma { get; set; }

        [JsonPropertyName("block_name")]
        public string? BlockName { get; set; }

        [JsonPropertyName("other_name")]
        public string? OtherName { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }
    }
}