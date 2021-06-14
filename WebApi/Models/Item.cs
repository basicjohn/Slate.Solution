using System;

namespace WebApi.Models
{
  public class Item
  {
    public Item()
    {
      ItemId = Guid.NewGuid().ToString();
    }
    public string ItemId { get; set; }
    public string Name { get; set; }
  }
}