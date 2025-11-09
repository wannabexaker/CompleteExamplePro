
using System;
using System.Linq;
using CompleteExampleApp.Models.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CompleteExampleApp.Data
{
    public static class DbInitializer
    {
        public static void EnsureCreatedAndSeed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            ctx.Database.EnsureCreated();

            if (!ctx.Cities.Any())
            {
                ctx.Cities.AddRange(
                    new City { Name = "Munich" },
                    new City { Name = "Berlin" }
                );
                ctx.SaveChanges();
            }

            if (!ctx.Locations.Any())
            {
                ctx.Locations.AddRange(
                    new Location { Title="Beerhall", Street="Beerstreet", HouseNumber="5A", PostalCode="80135", CityName="Munich" },
                    new Location { Title="The Green One", Street="Veggiestreet", HouseNumber="12", PostalCode="12141", CityName="Berlin" }
                );
                ctx.SaveChanges();
            }

            if (!ctx.AppUsers.Any())
            {
                var u1 = new AppUser
                {
                    FirstName = "Max",
                    LastName = "Schwarz",
                    Birthdate = new DateTime(1989, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                    Email = "max@test.com"
                };
                ctx.AppUsers.Add(u1);
                ctx.SaveChanges();
                ctx.Organizers.Add(new Organizer { UserId = u1.Id, Password = "mypw1" });
                ctx.SaveChanges();
            }

            if (!ctx.Tags.Any())
            {
                ctx.Tags.AddRange(new Tag { Name="socialize" }, new Tag { Name="learn" });
                ctx.SaveChanges();
            }

            if (!ctx.Events.Any())
            {
                var loc = ctx.Locations.First();
                var org = ctx.Organizers.FirstOrDefault();
                ctx.Events.Add(new Event { Name="A first event", DatePlanned=DateTime.UtcNow, Description="Demo", MaxParticipants=20, MinAge=18, LocationId=loc.Id, OrganizerId=org?.UserId });
                ctx.SaveChanges();
            }
        }
    }
}
