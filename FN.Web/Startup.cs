using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FN.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Major Code Smell",
        "S2325:Methods should not be static",
        Justification = "ASP.NET Core Startup methods must remain instance methods for extensibility")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Major Code Smell",
        "S2325:Methods should not be static",
        Justification = "ASP.NET Core Startup methods must remain instance methods for extensibility")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // default HSTS value 30 days.
                // change for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
