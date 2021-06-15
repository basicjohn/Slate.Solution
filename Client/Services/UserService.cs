using Slate.Shared.Entities;
using Slate.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slate.Client.Services
{
  public interface IUserService
  {
    Task<IEnumerable<User>> GetAll();
  }

  public class UserService : IUserService
  {
    private readonly IHttpService _httpService;

    public UserService(IHttpService httpService)
    {
      _httpService = httpService;
    }

    public async Task<IEnumerable<User>> GetAll()
    => await _httpService.Get<IEnumerable<User>>("/users");

  }
}