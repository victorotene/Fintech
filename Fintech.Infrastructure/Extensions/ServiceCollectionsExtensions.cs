using Fintech.Domain.Entities;
using Fintech.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public static class ServiceCollectionsExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FintechDB");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'FintechDB' is not configured.");
        }

        bool environment = Convert.ToBoolean(configuration["Application:isLive"]);
        
        services.AddDbContext<FintechDbContext>(options =>
        {
            options.UseSqlServer(connectionString);

            if (!environment)
            {
                options.EnableSensitiveDataLogging(); // Enable sensitive data logging in non-live environments
            }
        });
        
        // Configure Identity
        /*services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<FintechDbContext>()
            .AddDefaultTokenProviders();*/

        // Uncomment and configure these services if needed
        // services.AddScoped<IFintechSeeders, FintechSeeders>();
    }
}