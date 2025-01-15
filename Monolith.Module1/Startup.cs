using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Monolith.Module1.Shared;
using System.Security.AccessControl;
using IStartup = Monolith.Shared.IStartup;

namespace Monolith.Module1
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITestService, TestService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CustomMiddleware>();
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }
    }
}