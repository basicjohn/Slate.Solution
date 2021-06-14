using Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blazor.Services
{
  public interface IHttpService
  {
    Task<T> Get<T>(string uri);
    Task<T> Post<T>(string uri, object value);
  }

  public class HttpService : IHttpService
  {
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;
    //private readonly IConfiguration _configuration;

    public HttpService(
        HttpClient httpClient,
        NavigationManager navigationManager,
        ILocalStorageService localStorageService
    //IConfiguration configuration
    )
    {
      _httpClient = httpClient;
      _navigationManager = navigationManager;
      _localStorageService = localStorageService;
      //_configuration = configuration;
    }

    public async Task<T> Get<T>(string uri)
    {
      var request = new HttpRequestMessage(HttpMethod.Get, uri);
      return await SendRequest<T>(request);
    }

    public async Task<T> Post<T>(string uri, object value)
    {
      string cereal = JsonSerializer.Serialize(value);
      StringContent content = new(cereal, Encoding.UTF8, "application/json");
      HttpRequestMessage request = new(HttpMethod.Post, uri)
      {
        Content = content
      };
      return await SendRequest<T>(request);
    }

    // helper methods

    private async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
      // add jwt auth header if user is logged in and request is to the api url
      var user = await _localStorageService.GetItem<User>("user");
      var isApiUrl = !request.RequestUri.IsAbsoluteUri;

      if (user != null && isApiUrl)
        request.Headers.Authorization
        = new AuthenticationHeaderValue("Bearer", user.Token);

      using var response = await _httpClient.SendAsync(request);

      // auto logout on 401 response
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        _navigationManager.NavigateTo("logout");
        return default;
      }

      // throw exception on error response
      if (!response.IsSuccessStatusCode)
      {
        var error = await response.Content
                          .ReadFromJsonAsync<Dictionary<string, string>>();
        throw new Exception(error["message"]);
      }

      return await response.Content.ReadFromJsonAsync<T>();
    }
  }
}