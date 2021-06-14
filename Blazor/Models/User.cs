using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
  public class User
  {
    [Key]
    public string Email { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }
  }
}
