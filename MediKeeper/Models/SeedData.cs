using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediKeeper.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MediKeeperItemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MediKeeperItemContext>>()))
            {
                // Look for any Items.
                if (context.Item.Any())
                {
                    return;   // DB has been seeded
                }

                context.Item.AddRange(
                    new Item
                    {
                        ID = 001,
                        ItemName = "ITEM 1",
                        Cost = 100
                    },
                    new Item
                    {
                        ID = 002,
                        ItemName = "ITEM 2",
                        Cost = 200
                    },
                    new Item
                    {
                        ID = 003,
                        ItemName = "ITEM 1",
                        Cost = 250
                    },
                    new Item
                    {
                        ID = 004,
                        ItemName = "ITEM 3",
                        Cost = 300
                    },
                    new Item
                    {
                        ID = 005,
                        ItemName = "ITEM 4",
                        Cost = 50
                    },
                    new Item
                    {
                        ID = 006,
                        ItemName = "ITEM 4",
                        Cost = 40
                    },
                    new Item
                    {
                        ID = 007,
                        ItemName = "ITEM 2",
                        Cost = 200
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
