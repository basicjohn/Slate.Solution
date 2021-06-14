using Blazor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Net;

namespace Blazor.Helpers
{
  public class AppRouteView : RouteView
  {
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    protected override void Render(RenderTreeBuilder builder)
    {
      var authAttributeOfRoute = Attribute.GetCustomAttribute(
        RouteData.PageType,
        typeof(AuthorizeAttribute)
      );
      var papersPlease = authAttributeOfRoute != null;
      var gotNoPapers = AuthenticationService.User == null;
      if (papersPlease && gotNoPapers)
      {
        var returnUrl = WebUtility
                        .UrlEncode(new Uri(NavigationManager.Uri).PathAndQuery);
        NavigationManager.NavigateTo($"login?returnUrl={returnUrl}");
      }
      else
      {
        base.Render(builder);
      }
    }
  }
}