using System.Collections.Generic;
using System.Linq;
using Slate.Shared.Entities;

namespace Slate.Shared.Models
{
  public class AuthenticateResponse
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Id { get; set; }
    public string Token { get; set; }
    public AuthenticateResponse(User user, string token)
    {
      Id = user.Id;
      Name = user.Name;
      Email = user.Email;
      Token = token;
    }
  }
}
