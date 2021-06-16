using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Slate.Shared.Entities
{
  public class Board
  {
    public Board(string ownerId)
    {
      Id = Guid.NewGuid().ToString();
      OwnerId = ownerId;
      EditorId = ownerId;
      URI = Id;
    }
    public string Id { get; set; }
    public string URI { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    [Required] public string OwnerId { get; set; }
    public virtual User Owner { get; set; }

    [Required] public string EditorId { get; set; }
    public virtual User Editor { get; set; }

    public DateTime EditorExpiration { get; set; }

  }
}
