using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slate.Server.Services;

namespace Slate.Server.Helpers
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
      _next = next;
      _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
      var token = context.Request.Headers["Authorization"]
                  .FirstOrDefault()?.Split(" ").Last();

      if (token != null)
        AttachUserToContext(context, userService, token);

      await _next(context);
    }

    private void AttachUserToContext(
      HttpContext context,
      IUserService userService,
      string token
    )
    {
      try
      {
        var sth = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tvp = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          // cornflourblue: clockskew zero so tokens expire on time, not 5 minutes later
          ClockSkew = TimeSpan.Zero
        };

        sth.ValidateToken(token, tvp, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userIdField = jwtToken.Claims.First(x => x.Type == "id");
        var userId = userIdField.Value;
        // cornflourblue: attach user to context on successful jwt validation
        context.Items["User"] = userService.GetById(userId);
      }
      catch
      {
        // Console.WriteLine("JWT MID - CATCH BLOCK - AttachUserToContext Method - Not Authenticated");
        // do nothing if jwt validation fails
        // user is not attached to context so request won't have access to secure routes
      }
    }
  }
}