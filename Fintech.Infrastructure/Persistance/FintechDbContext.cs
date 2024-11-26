using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.Persistance;

public class FintechDbContext(DbContextOptions<FintechDbContext> options) : DbContext(options)
{
    internal DbSet<> Name { get; set; }
    
    /*
     *
     *
     *protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
       
           // Configuring a one-to-one relationship for the Address property of Restaurant
           modelBuilder.Entity<Restaurant>()
               .OwnsOne(r => r.Address);
       
           // Configuring a one-to-many relationship between Restaurant and Dishes
           modelBuilder.Entity<Restaurant>()
               .HasMany(r => r.Dishes)
               .WithOne(d => d.Restaurant)
               .HasForeignKey(d => d.RestaurantId);
       }
       
     *
     *
     * 
     */
}