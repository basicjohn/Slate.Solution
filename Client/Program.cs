using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Slate.Client.Helpers;
using Slate.Client.Services;

namespace Slate.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      // builder.Services.AddScoped(
      //   sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }
      //   );
      builder.Services
        .AddScoped<IAuthenticationService, AuthenticationService>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<IBoardService, BoardService>()
        .AddScoped<IHttpService, HttpService>()
        .AddScoped<ILocalStorageService, LocalStorageService>();

      // configure http client
      builder.Services.AddScoped(x =>
      {
        var apiUrl = new Uri(builder.Configuration["apiUrl"]);
        return new HttpClient() { BaseAddress = apiUrl };
      });

      var host = builder.Build();

      var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
      await authenticationService.Initialize();

      await host.RunAsync();
    }
  }
}
