using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Slate.Shared.Entities
{
  public class User
  {
    public User()
    {
      Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public byte[] Salt { get; set; }
    [JsonIgnore]
    public string Hash { get; set; }
    public string Token {get;set;}
  }
}
