using Microsoft.EntityFrameworkCore;

namespace VendorEvents_1.Models
{
    public class EventContext : DbContext
    {
        public EventContext (DbContextOptions<EventContext> options)
            : base (options)
            {
            }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) //helps EF core identify composite primary key in eventproduct table (set to two PKs).
        {
            modelBuilder.Entity<EventProduct>().HasKey(e => new {e.ProductID, e.EventID});
        }

        public DbSet<Event> Event {get; set;} = default!;
        public DbSet<Product> Product {get; set;} = default!;
        public DbSet<EventProduct> EventProduct {get; set;} = default!; 
    }
}