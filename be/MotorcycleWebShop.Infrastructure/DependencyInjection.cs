using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Domain.Common;
using MotorcycleWebShop.Domain.Interfaces;
using MotorcycleWebShop.Infrastructure.Identity;
using MotorcycleWebShop.Infrastructure.Persistence;
using MotorcycleWebShop.Infrastructure.Services;

namespace MotorcycleWebShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {

            services.AddDbContext<ApplicationDbContext>((services, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), optBuilder =>
                    {
                        optBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    });
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
