using PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data;

public class Seed
{

    public static void Populate(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
    }

    private static void SeedData(AppDbContext context)
    {
        try
        {
            context.Database.Migrate();
        } catch (Exception e)
        {

        }
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding data");

            context.Platforms.AddRange(
                new Platform
                {
                    Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"
                }, 
                new Platform
                {
                    Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"
                }, 
                new Platform
                {
                    Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }
    }
}