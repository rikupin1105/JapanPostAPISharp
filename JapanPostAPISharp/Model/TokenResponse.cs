using System.Text.Json.Serialization;

namespace JapanPostAPISharp.Model
{
    public class TokenResponse
    {
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }

}
