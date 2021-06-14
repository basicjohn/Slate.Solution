using Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.Services
{
  public interface IAuthenticationService
  {
    User User { get; }
    Task Initialize();
    Task Register(
      string email,
      string name,
      string password1,
      string password2
      );
    Task Login(string email, string password);
    Task Logout();
  }

  public class AuthenticationService : IAuthenticationService
  {
    private readonly IHttpService _httpService;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;

    public User User { get; private set; }

    public AuthenticationService(
        IHttpService httpService,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService
    )
    {
      _httpService = httpService;
      _navigationManager = navigationManager;
      _localStorageService = localStorageService;
    }

    public async Task Initialize()
    {
      User = await _localStorageService.GetItem<User>("user");
    }

    public async Task Login(string email, string password)
    {
      User = await _httpService.Post<User>(
        "/users/authenticate",
        new { email, password }
        );
      await _localStorageService.SetItem("user", User);
    }

    public async Task Register(
      string email,
      string name,
      string password1,
      string password2
      )
    {
      User = await _httpService.Post<User>(
        "/users/register",
        new
        {
          email,
          name,
          password1,
          password2
        }
      );
      await _localStorageService.SetItem("user", User);
    }

    public async Task Logout()
    {
      User = null;
      await _localStorageService.RemoveItem("user");
      _navigationManager.NavigateTo("login");
    }
  }
}