using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Slate.WebApi.Entities
{
  public class User
  {
    public string Name { get; set; }
    [Key]
    public string Email { get; set; }
    [JsonIgnore]
    public byte[] Salt { get; set; }
    [JsonIgnore]
    public string Hash { get; set; }
  }
}
