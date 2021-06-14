using Slate.WebApi.Entities;

namespace Slate.WebApi.Models
{
  public class RegisterResponse
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public byte[] Salt { get; set; }
    public string Hash { get; set; }

    public RegisterResponse(User user)
    {
      Name = user.Name;
      Email = user.Email;
    }
  }
}
