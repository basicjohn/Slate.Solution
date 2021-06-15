using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs
{
  public class SlateHub : Hub
  {
    public async Task SendMessage(string message)
    {
      Console.WriteLine("SLATEHUB - HIT SENDMESSAGE ROUTE {0}", message);
      await Clients.All.SendAsync("ReceiveMessage", message);
    }
  }
}
