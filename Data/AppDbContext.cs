using Microsoft.EntityFrameworkCore;
using CompleteExampleApp.Models.Entities;

namespace CompleteExampleApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Organizer> Organizers => Set<Organizer>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<EventUser> EventUsers => Set<EventUser>();
        public DbSet<EventTag> EventTags => Set<EventTag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys
            modelBuilder.Entity<City>().HasKey(c => c.Name);
            modelBuilder.Entity<Tag>().HasKey(t => t.Name);
            modelBuilder.Entity<Organizer>().HasKey(o => o.UserId);

            // Organizer AppUser (1-to-1)
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.AppUser)
                .WithOne(u => u.Organizer)
                .HasForeignKey<Organizer>(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location City (many-to-1)
            modelBuilder.Entity<Location>()
                .HasOne(l => l.City)
                .WithMany()
                .HasForeignKey(l => l.CityName)
                .OnDelete(DeleteBehavior.Restrict);

            // EventUser composite key
            modelBuilder.Entity<EventUser>().HasKey(eu => new { eu.EventId, eu.UserId });
            modelBuilder.Entity<EventUser>()
                .HasOne(eu => eu.AppUser)
                .WithMany(u => u.EventUsers!)
                .HasForeignKey(eu => eu.UserId);

            // EventTag composite key
            modelBuilder.Entity<EventTag>().HasKey(et => new { et.EventId, et.TagName });
            modelBuilder.Entity<EventTag>()
                .HasOne(et => et.Tag)
                .WithMany(t => t.EventTags!)
                .HasForeignKey(et => et.TagName);

            // Event Location
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Location)
                .WithMany(l => l.Events!)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull);

            // Event Organizer
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany()
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.SetNull);

            // *** FIX: Make all table names lowercase (for PostgreSQL) ***
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName != null)
                    entity.SetTableName(tableName.ToLowerInvariant());
            }
        }
    }
}
