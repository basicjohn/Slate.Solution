using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Slate.Server.Hubs
{
  public class SlateHub : Hub
  {
    public async Task SendMessage(string message)
    {
      Console.WriteLine("UserIdentifier {0}", Context.UserIdentifier);
      Console.WriteLine("ConnectionId {0}", Context.ConnectionId);
      Console.WriteLine("Features {0}", Context.Features);
      Console.WriteLine("Items {0}", Context.Items);
      Console.WriteLine("User {0}", Context.User);
      Console.WriteLine("SLATEHUB - HIT SENDMESSAGE ROUTE {0}", message);
      await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task SendMessageByUser(string message, string currentUserId)
    {
      // if the userid is the OWNER of the board, send receive message to all connected users of that board
      // if the userId is not the OWNER, do nothing?
      Console.WriteLine("UserIdentifier {0}", Context.UserIdentifier);
      Console.WriteLine("ConnectionId {0}", Context.ConnectionId);
      Console.WriteLine("Features {0}", Context.Features);
      Console.WriteLine("currentUserId {0}", currentUserId);
      Console.WriteLine("User {0}", Context.User);
      Console.WriteLine("SLATEHUB - HIT SENDMESSAGE ROUTE {0}", message);
      await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task AddToGroup(string groupName)
    {
      Console.WriteLine("SLATEHUB - add to group - ConnID {0}. Board Name: {1}", Context.ConnectionId, groupName);
      await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
      await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
    }

    public Task SendMessageToGroup(string groupName, string message)
    {
      Console.WriteLine("SLATEHUB - send to group - ConnID {0}. Board Name: {1}", Context.ConnectionId, groupName);
      return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
    }
  }
}
