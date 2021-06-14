using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Helpers
{
  public class FakeBackendHandler : HttpClientHandler
  {
    protected override async Task<HttpResponseMessage> SendAsync(
      HttpRequestMessage request,
      CancellationToken cancellationToken
    )
    {
      var testUser = new
      {
        Id = 1,
        Username = "test",
        Password = "test",
        FirstName = "Test",
        LastName = "User"
      };
      var users = new[] { testUser };
      var path = request.RequestUri.AbsolutePath;
      var method = request.Method;

      return path switch
      {
        "/users/authenticate"
          when method == HttpMethod.Post
          => await authenticate(),
        "/users"
          when method == HttpMethod.Get
          => await getUsers(),
        _
          => await base.SendAsync(request, cancellationToken)
      };

      // route functions

      async Task<HttpResponseMessage> authenticate()
      {
        var bodyJson = await request.Content.ReadAsStringAsync(cancellationToken);
        var body = JsonSerializer.Deserialize<Dictionary<string, string>>(bodyJson);
        var user = users.FirstOrDefault(
          x =>
            x.Username == body["username"]
            &&
            x.Password == body["password"]
        );

        return user == null
            ? await error("Username or password is incorrect")
            : await ok(new
            {
              user.Id,
              user.Username,
              user.FirstName,
              user.LastName,
              Token = "fake-jwt-token"
            });
      }

      async Task<HttpResponseMessage> getUsers()
      => isLoggedIn() ? await ok(users) : await unauthorized();

      // helper functions

      async Task<HttpResponseMessage> ok(object body)
      => await jsonResponse(HttpStatusCode.OK, body);

      async Task<HttpResponseMessage> error(string message)
      => await jsonResponse(HttpStatusCode.BadRequest, new { message });

      async Task<HttpResponseMessage> unauthorized()
      => await jsonResponse(
        HttpStatusCode.Unauthorized,
        new { message = "Unauthorized" }
        );

      async Task<HttpResponseMessage> jsonResponse(
        HttpStatusCode statusCode,
        object content
      )
      {
        var response = new HttpResponseMessage
        {
          StatusCode = statusCode,
          Content = new StringContent(
            JsonSerializer.Serialize(content),
            Encoding.UTF8, "application/json"
            )
        };

        // delay to simulate real api call
        await Task.Delay(500, cancellationToken);

        return response;
      }

      bool isLoggedIn()
      => request.Headers.Authorization?.Parameter == "fake-jwt-token";
    }
  }
}