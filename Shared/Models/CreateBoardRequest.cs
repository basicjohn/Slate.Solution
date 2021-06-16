using System.ComponentModel.DataAnnotations;

namespace Slate.Shared.Models
{
  public class CreateBoardRequest
  {
    [Required] public string ownerId { get; set; }
  }
}