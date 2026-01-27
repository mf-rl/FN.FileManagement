using FN.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using FN.Entities;
using Microsoft.Extensions.Logging;
using FN.DataLayer.DataContext;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace FN.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddOptions();
            services.Configure<CustomConfig>(Configuration.GetSection("CustomConfig"));

            if (Configuration["AppConfig:UseInMemoryDatabase"] == "true")
                services.AddDbContext<ConnectionDataContext>(opt => opt.UseInMemoryDatabase("InMemoryDatabase"));
            else 
                services.AddDbContext<ConnectionDataContext>(opt => 
                    opt.UseSqlServer(Configuration.GetConnectionString("StuffDbConnectionString")));
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );
            });
            services.AddControllers();
            services.AddMvc().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            services
                .AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "FN.WebApi", Version = "v1" });
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .AddApplicationServices()
                .AddBusinessServices()
                .AddDataLayer()
                ;
        }
        public static void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
            {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FN.WebApi v1");
                });
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ((ClaimsIdentity)principal.Identity).AddClaim(new Claim("now", DateTime.Now.ToString()));
            return Task.FromResult(principal);
        }
    }
}
