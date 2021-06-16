using Microsoft.AspNetCore.Mvc;
using System;

using Slate.Server.Helpers;
using Slate.Server.Models;
using Slate.Server.Services;
using Slate.Shared.Entities;
using Slate.Shared.Models;

namespace Slate.Server.Controllers
{
  [ApiController]
  [Route("boards")]
  public class BoardsController : ControllerBase
  {
    private readonly SlateServerContext _db;

    public BoardsController(SlateServerContext db)
    {
      _db = db;
    }

    [HttpPost("")]
    public IActionResult Create(CreateBoardRequest cbr)
    {
      Console.WriteLine("BOARDS CONTROLLER - CREATE NEW BOARD - owner: {0}", cbr.ownerId);
      Board b = new(cbr.ownerId);
      _db.Boards.Add(b);
      _db.SaveChanges();
      return Ok();
    }

    [HttpGet("")]
    public IActionResult Read(string id)
    {
      return Ok();
    }
    [HttpPut("")]
    public IActionResult Update(string id, Board board)
    {
      return Ok();
    }
    [HttpDelete("")]
    public IActionResult Delete(string id)
    {
      return Ok();
    }
  }
}
