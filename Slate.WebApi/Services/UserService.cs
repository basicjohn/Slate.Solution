using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Slate.WebApi.Entities;
using Slate.WebApi.Helpers;
using Slate.WebApi.Models;

namespace Slate.WebApi.Services
{
  public interface IUserService
  {
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    (string, User) Register(RegisterRequest model);
    IEnumerable<User> GetAll();
    User GetByEmail(string email);
  }

  public class UserService : IUserService
  {
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    // private readonly List<User> _users = new()
    // {
    //   new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test" }
    // };

    private readonly SlateWebApiContext _db;

    private readonly AppSettings _appSettings;

    public UserService(SlateWebApiContext db, IOptions<AppSettings> appSettings)
    {
      _db = db;
      _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
      var user = _db.Users.FirstOrDefault(u => u.Email == model.Email);

      // return null if user not found
      if (user == null) return null;

      // authentication successful so generate jwt token
      return Hasher.Verify(model.Password, user)
        ? new AuthenticateResponse(user, GenerateJwtToken(user))
        : null;
    }

    public (string, User) Register(RegisterRequest model)
    {
      var existingUser = _db.Users.SingleOrDefault(u => u.Email == model.Email);

      if (existingUser != null) return ("user already exists", null);
      if (model.Password1 != model.Password2) return ("passwords don't match", null);

      var (salt, hash) = Hasher.Make(model.Password1);
      // authentication successful so generate jwt token
      User u = new()
      {
        Email = model.Email,
        Name = model.Name,
        Salt = salt,
        Hash = hash
      };
      _db.Users.Add(u);
      _db.SaveChanges();
      return ($"successfully registered {u.Name}!", u);
    }

    public IEnumerable<User> GetAll() => _db.Users.ToList();

    public User GetByEmail(string email) => _db.Users.FirstOrDefault(u => u.Email == email);

    // helper methods

    private string GenerateJwtToken(User user)
    {
      // generate token that is valid for 7 days
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("email", user.Email) }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(
          new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature
          )
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}