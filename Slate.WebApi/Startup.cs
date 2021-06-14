// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Slate.WebApi.Helpers;
using Slate.WebApi.Models;
using Slate.WebApi.Services;

namespace Slate.WebApi
{
  public class Startup
  {
    public Startup(IConfiguration config)
    {
      Config = config;
    }

    public IConfiguration Config { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddApiVersioning(o =>
        {
          o.ReportApiVersions = true;
          o.AssumeDefaultVersionWhenUnspecified = true;
          o.DefaultApiVersion = new(0, 0);
        }
      );
      services.AddControllers();
      services.AddDbContext<SlateWebApiContext>(options => options
        .UseMySql(Config["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Config["ConnectionStrings:DefaultConnection"])));
      // cornflourblue: configure strongly typed settings object
      services.Configure<AppSettings>(Config.GetSection("AppSettings"));
      // cornflourblue: configure DI for application services
      services.AddScoped<IUserService, UserService>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      // cornflourblue: global cors policy
      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      // custom jwt auth middleware
      app.UseMiddleware<JwtMiddleware>();
      // app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
