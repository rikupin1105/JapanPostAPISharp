namespace JPZipSharp
{
    public class JapanPostApiOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string BaseUrl { get; set; } = "https://api.da.pf.japanpost.jp/api/v1/";
    }
}
