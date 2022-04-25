using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentAcquire.Listing.Service.Data;

namespace StudentAcquire.Listing.Service
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var context = app.ApplicationServices.CreateScope())
            {
                SeedData(context.ServiceProvider.GetService<ListingServiceContext>(), isProd);
            }
        }

        private static void SeedData(ListingServiceContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Migrating Database...");
                try
                {
                     context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Error Migrating Database: {ex.Message}");
                }
               
            }

            if(!context.Listing.Any())
            {
                context.Listing.AddRange(
                    new Models.Listing
                    {
                        Name = "Test Listing 1",
                        Description = "This is a test listing",
                        Price_Low = 100,
                        Price_High = 1000,
                        Sold = true,
                        Seller = new Models.Seller("Test Seller 1", "test_seller_1")
                    },
                    new Models.Listing
                    {
                        Name = "Test Listing 2",
                        Description = "This is a test listing",
                        Price_Low = 200,
                        Price_High = 2000,
                        Sold = true,
                        Seller = new Models.Seller("Test Seller 2", "test_seller_2")
                    },
                    new Models.Listing
                    {
                        Name = "Test Listing 3",
                        Description = "This is a test listing",
                        Price_Low = 300,
                        Price_High = 3000,
                        Sold = true,
                        Seller = new Models.Seller("Test Seller 3", "test_seller_3")
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data in the database");
            }
        }
    }
}