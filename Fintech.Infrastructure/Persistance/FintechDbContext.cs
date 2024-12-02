using Fintech.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.Persistance;

public class FintechDbContext : IdentityDbContext<User>
{
    public FintechDbContext(DbContextOptions<FintechDbContext> options) : base(options)
    {
    }

    // Define DbSets for your entities, e.g.:
    // public DbSet<YourEntity> YourEntities { get; set; }
}