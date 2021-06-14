using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Models
{
  public class WebApiContext : DbContext
  {
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public WebApiContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}