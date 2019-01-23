using System;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class CarSalesContextExtensions
    {
        public static void EnsureDbInitialized(this CarSalesContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.CarEntries.AddRange(
                new CarEntry
                {
                    Notes = "Sales 123",
                    CreateDate = DateTimeOffset.UtcNow
                },
                new CarEntry
                {
                    Notes = "Sales 098",
                    CreateDate = DateTimeOffset.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
}
