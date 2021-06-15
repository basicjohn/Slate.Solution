using Microsoft.AspNetCore.Mvc;
using Slate.Server.Helpers;
using Slate.Server.Models;
using Slate.Server.Services;

namespace Slate.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll() => Ok(_userService.GetAll());
  }
}
