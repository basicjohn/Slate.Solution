using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
  public class RegisterRequest
  {
    [Required] public string Email { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Password1 { get; set; }
    [Required] public string Password2 { get; set; }
  }
}