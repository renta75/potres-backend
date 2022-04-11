using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Potres.WebApi.Models
{
  public class LoginModel
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; }


        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
