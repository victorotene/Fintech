using Fintech.Infrastructure.Persistance;
using Fintech.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fintech.Infrastructure.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FintechDB");
        services.AddDbContext<FintechDbContext>(options => options.UseSqlServer(connectionString));
        
        services.AddScoped<IFintechSeeders, FintechSeeders>();
    }
}