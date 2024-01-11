using Aspnet_Core_Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aspnet_Core_Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ... other services

            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthConnectionString")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();

            // ... other configurations
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ... other configurations

            app.UseAuthentication();
            app.UseAuthorization();

            // ... other middleware configurations
        }
    }
}
