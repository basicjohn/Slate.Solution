using Slate.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slate.Client.Services
{
  public interface IBoardService
  {
    Task<IEnumerable<Board>> GetAll();
  }

  public class BoardService : IBoardService
  {
    private readonly IHttpService _httpService;

    public BoardService(IHttpService httpService)
    {
      _httpService = httpService;
    }

    public async Task<IEnumerable<Board>> GetAll()
    => await _httpService.Get<IEnumerable<Board>>("/boards/all");

  }
}