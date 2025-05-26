namespace JPZipSharp.Model
{
    public class AddressZipRequestParameter
    {
        public string? pref_code { get; set; }
        public string? pref_name { get; set; }
        public string? pref_kana { get; set; }
        public string? pref_roma { get; set; }
        public string? city_code { get; set; }
        public string? city_name { get; set; }
        public string? city_kana { get; set; }
        public string? city_roma { get; set; }
        public string? town_name { get; set; }
        public string? town_kana { get; set; }
        public string? town_roma { get; set; }
        public string? freeword { get; set; }
        public int flg_getcity { get; set; } = 0;
        public int flg_getpref { get; set; } = 0;
        public int page { get; set; } = 1;
        public int limit { get; set; } = 1000;
    }

}
