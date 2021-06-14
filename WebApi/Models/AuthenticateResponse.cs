using WebApi.Entities;

namespace WebApi.Models
{
  public class AuthenticateResponse
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(User user, string token)
    {
      Name = user.Name;
      Email = user.Email;
      Token = token;
    }
  }
}
