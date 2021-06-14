using System.ComponentModel.DataAnnotations;

namespace Slate.WebApi.Models
{
  public class AuthenticateRequest
  {
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
  }
}