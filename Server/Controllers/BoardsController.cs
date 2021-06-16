using Microsoft.AspNetCore.Mvc;
using System;

using Slate.Server.Helpers;
using Slate.Server.Services;
using Slate.Shared.Models;

namespace Slate.Server.Controllers
{
  [Authorize]
  [ApiController]
  [Route("boards")]
  public class BoardsController : ControllerBase
  {
    [HttpPost("")]
    public IActionResult Create()
    {
      return Ok();
    }

    [HttpGet("")]
    public IActionResult Read()
    {
      return Ok();
    }
    [HttpPut("")]
    public IActionResult Update()
    {
      return Ok();
    }
    [HttpDelete("")]
    public IActionResult Delete(strng)
    {
      return Ok();
    }
  }
}
