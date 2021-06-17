using Microsoft.AspNetCore.Mvc;
using System;

using Slate.Server.Helpers;
using Slate.Server.Services;
using Slate.Shared.Models;

namespace Slate.Server.Controllers
{
  [ApiController]
  [Route("users")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
      var response = _userService.Register(model);
      var (message, user) = response;

      if (user == null) return BadRequest(new { message });

      return Ok(response);
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model);
      Console.WriteLine($"SERVER - USER CONTROLLER - response: {response}");
      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Read()
    {
      Console.WriteLine();
      return Ok(_userService.GetAll());
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
      Console.WriteLine();
      return Ok(_userService.GetAll());
    }
  }
}
