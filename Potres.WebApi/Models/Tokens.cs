using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Potres.WebApi.ViewModels
{    
    public class Tokens
    {
        [Required]
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [Required]
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
