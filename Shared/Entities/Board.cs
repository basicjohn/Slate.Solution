using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Slate.Shared.Entities
{
  public class Board
  {
    public Board()
    {
      Id = Guid.NewGuid().ToString();
      URI = Id;
    }
    public string Id { get; set; }
    public string URI { get; set; }
    public string Name { get; set; }
    public string OwnerId { get; set; }
    public string EditorId { get; set; }
    public DateTime EditorExpiration { get; set; }
    public string Content { get; set; }
  }
}
