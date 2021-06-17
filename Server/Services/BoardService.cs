using System.Collections.Generic;
using System.Linq;

using Slate.Server.Models;
using Slate.Shared.Entities;

namespace Slate.Server.Services
{
  public interface IBoardService
  {
    IEnumerable<Board> GetAll();
    Board GetById(string id);
  }

  public class BoardService : IBoardService
  {
    private readonly SlateServerContext _db;
    public BoardService(SlateServerContext db)
    {
      _db = db;
    }

    public IEnumerable<Board> GetAll() => _db.Boards.ToList();

    public Board GetById(string id) => _db.Boards.FirstOrDefault(b => b.Id == id);
  }
}