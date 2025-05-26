namespace JapanPostAPISharp
{
    public class JapanPostApiOptions(string clientId, string clientSecret, string baseUrl = "https://api.da.pf.japanpost.jp/api/v1/")
    {
        public string ClientId { get; set; } = clientId;
        public string ClientSecret { get; set; } = clientSecret;
        public string BaseUrl { get; set; } = baseUrl;
    }
}
