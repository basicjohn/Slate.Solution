using Slate.Server.Entities;

namespace Slate.Server.Models
{
  public class RegisterResponse
  {
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public byte[] Salt { get; set; }
    public string Hash { get; set; }

    public RegisterResponse(User user)
    {
      UserId = user.Id;
      Name = user.Name;
      Email = user.Email;
    }
  }
}
