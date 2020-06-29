using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ConfTool.Server.Model
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ConferencesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ConferencesDbContext>>()))
            {
                if (context.Conferences.Any())
                {
                    return;
                }

                context.Conferences.AddRange(
                     new Conference
                    {
                        ID = Guid.NewGuid(),
                        Title = "Developer Week 20",
                        City = "Nürnberg",
                        Country = "Germany",
                        DateFrom = new DateTime(2020, 11, 2),
                        DateTo = new DateTime(2020, 11, 6),
                        Url = "https://www.developer-week.de/"
                    },
                    new Conference
                    {
                        ID = Guid.NewGuid(),
                        Title = "BASTA! 2020",
                        City = "Mainz",
                        Country = "Germany",
                        DateFrom = new DateTime(2020, 9, 21),
                        DateTo = new DateTime(2020, 9, 25),
                        Url = "https://www.basta.net/"
                    },
                    new Conference
                    {
                        ID = Guid.NewGuid(),
                        Title = "DWX Home",
                        City = "Neustadt am Main",
                        Country = "Germany",
                        DateFrom = new DateTime(2020, 6, 19),
                        DateTo = new DateTime(2020, 7, 3),
                        Url = "https://www.developer-week.de/dwx-home/#/"
                    },
                    new Conference
                    {
                        ID = Guid.NewGuid(),
                        Title = "Global Azure Bootcamp 2020",
                        City = "Hamburg",
                        Country = "Germany",
                        DateFrom = new DateTime(2020, 4, 25),
                        DateTo = new DateTime(2020, 4, 25),
                        Url = "https://sessionize.com/global-azure-bootcamp-hamburg/"
                    },
                    new Conference
                    {
                        ID = Guid.NewGuid(),
                        Title = "BASTA! Spring 2020",
                        City = "Frankfurt am Main",
                        Country = "Germany",
                        DateFrom = new DateTime(2020, 2, 24),
                        DateTo = new DateTime(2020, 2, 28),
                        Url = "https://www.basta.net/"
                    });

                context.SaveChanges();
            }
        }
    }
}
