using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slate.Shared.Entities
{
  public class User
  {
    public User()
    {
      Id = Guid.NewGuid().ToString();
      BoardsEditable = new HashSet<Board>();
      BoardsOwned = new HashSet<Board>();
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public byte[] Salt { get; set; }
    [JsonIgnore]
    public string Hash { get; set; }
    [NotMapped]
    public string Token {get;set;}

    [InverseProperty("Owner")]
    public virtual ICollection<Board> BoardsOwned { get; set; }

    [InverseProperty("Editor")]
    public virtual ICollection<Board> BoardsEditable { get; set; }
  }
}
