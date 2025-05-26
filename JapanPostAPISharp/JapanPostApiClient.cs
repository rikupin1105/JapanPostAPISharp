using JPZipSharp.Model;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JPZipSharp
{
    public class JapanPostApiClient : IJapanPostApiClient
    {
        private string? _token;
        private readonly HttpClient _httpClient;
        private readonly JapanPostApiOptions _options;

        public JapanPostApiClient(string clientId, string clientSecret, string baseUrl = "https://api.da.pf.japanpost.jp/api/v1/", HttpClient? httpClient = null)
        {
            _options = new JapanPostApiOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                BaseUrl = baseUrl
            };
            if(httpClient != null)
                _httpClient = httpClient;
            else
                _httpClient = new HttpClient();
        }

        public async Task<SearchCodeResponce> SearchCodeAsync(string serachCode, string ecuid = "", int page = 1, int limit = 1, int choikittype = 1, int searchtype = 1)
        {
            if (_token is null)
                await GetToken();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.BaseUrl}searchcode/{serachCode}?ec_uid={ecuid}&page={page}&limit={limit}&choikittype={choikittype}&searchtype={searchtype}")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            //何故かUAを入れないと403になる。ローカル環境だから？
            request.Headers.UserAgent.ParseAdd("JapanPostApiClient");
            var responce = await _httpClient.SendAsync(request);

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SearchCodeResponce>(content);
            }
            else
            {
                var content = await responce.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
        public async Task<AddressZipResponse> AddressZip(AddressZipRequestParameter addressZipRequestParameter, string ecuid)
        {
            if (_token is null)
                await GetToken();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_options.BaseUrl}addresszip?ec_uid={ecuid}")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(addressZipRequestParameter);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await _httpClient.SendAsync(request);

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<AddressZipResponse>(content);
                return response;
            }
            else
            {
                var content = await responce.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }


        private async Task GetToken()
        {
            var parameters = new Dictionary<string, string>()
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", _options.ClientId },
                    { "secret_key", _options.ClientSecret }
                };
            var json = JsonSerializer.Serialize(parameters);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_options.BaseUrl}j/token")
            };
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            
            //何故かUAを入れないと403になる。ローカル環境だから？
            request.Headers.UserAgent.ParseAdd("JapanPostApiClient");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(content);
                _token = tokenResponse.Token;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
        }
    }
}