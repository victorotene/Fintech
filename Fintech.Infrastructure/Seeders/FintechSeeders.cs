using Fintech.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.Seeders;

internal class FintechSeeders(FintechDbContext context) : IFintechSeeders
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Name.Any())
            {
                var names = GetNames();
                await context.Name.AddRangeAsync(names);
                await context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<string> GetNames()
    {
        yield return "John";
    }
}