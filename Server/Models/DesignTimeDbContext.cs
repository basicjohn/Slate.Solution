using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Slate.Server.Models
{
  public class SlateServerContextFactory : IDesignTimeDbContextFactory<SlateServerContext>
  {

    SlateServerContext IDesignTimeDbContextFactory<SlateServerContext>.CreateDbContext(string[] args)
    {
      // string path = System.IO.Directory.GetCurrentDirectory();
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SlateServerContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new SlateServerContext(builder.Options);
    }
  }
}