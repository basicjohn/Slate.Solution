using Microsoft.EntityFrameworkCore;
using Slate.WebApi.Entities;

namespace Slate.WebApi.Models
{
  public class SlateWebApiContext : DbContext
  {
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public SlateWebApiContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}