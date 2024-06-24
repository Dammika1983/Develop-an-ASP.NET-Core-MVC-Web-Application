using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMoto.Data;
using System;
using System.Linq;

namespace MvcMoto.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMotoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMotoContext>>()))
            {
                // Look for any motoes.
                if (context.Moto.Any())
                {
                    return;   // DB has been seeded
                }
                context.Moto.AddRange(
                    new Moto
                    {
                        Name = "Sergio Perez",
                        Circuit = "F1",
                        Team = "Red Bull Racing",
                        WorldRank = 2,
                        DriverNumber = 11
                    },
                    new Moto
                    {
                        Name = "Alex Bowman",
                        Circuit = "NASCAR",
                        Team = "Hendrick Motorsports",
                        WorldRank = 2,
                        DriverNumber = 48
                    },
                    new Moto
                    {
                        Name = "Ralph Boschung",
                        Circuit = "FIA F2",
                        Team = "Campos Racing",
                        WorldRank = 1,
                        DriverNumber = 25
                    },
                    new Moto
                    {
                        Name = "Oliver Goeth",
                        Circuit = "FIA F3",
                        Team = "Trident",
                        WorldRank = 2,
                        DriverNumber = 5
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
