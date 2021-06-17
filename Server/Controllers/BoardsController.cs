using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
    private readonly IBoardService _boardService;

    public BoardsController(SlateServerContext db, IBoardService boardService)
    {
      _db = db;
      _boardService = boardService;
    }

    [HttpPost("create")]
    public IActionResult Create(CreateBoardRequest cbr)
    {
      Console.WriteLine("BOARDS CONTROLLER - CREATE NEW BOARD - owner: {0}", cbr.ownerId);
      Board b = new(cbr.ownerId);
      _db.Boards.Add(b);
      _db.SaveChanges();
      return Ok();
    }

    [HttpGet("read")]
    public IActionResult Read(string id)
    {
      Console.WriteLine("SERVER - BOARDS CONTROLLER - GET by id {0}", id);
      Board b = _db.Boards.FirstOrDefault(b => b.Id == id);
      Console.WriteLine("SERVER - BOARDS CONTROLLER - retrieved board's id: {0}", b.Id);
      return Ok(new { board = b });
    }

    // [HttpGet("all")]
    // public IActionResult GetAll()
    // {
    //   IEnumerable<Board> myBoards = _db.Boards.ToList();
    //   Console.WriteLine($"BOARD CONTROLLER - read by owner - owner: {myBoards}");
    //   return Ok(myBoards);
    // }
    [Authorize]
    [HttpGet]
    [HttpGet("all")]
    public IActionResult GetAll()
    {
      Console.WriteLine();
      return Ok(_boardService.GetAll());
    }

    [HttpGet("owned")]
    public IActionResult ReadByOwner(string ownerId)
    {
      IEnumerable<Board> myBoards = _db.Boards.Where(b => b.OwnerId == ownerId).ToList();
      return Ok(myBoards);
    }


    [HttpGet("editable")]
    public IActionResult ReadByEditor(string editorId)
    {
      IEnumerable<Board> myBoards = _db.Boards.Where(b => b.EditorId == editorId).ToList();
      return Ok(myBoards);
    }

    [HttpPut("put")]
    public IActionResult Update(string id, Board board)
    {
      return Ok();
    }
    [HttpDelete("delete")]
    public IActionResult Delete(string id)
    {
      return Ok();
    }
  }
}
