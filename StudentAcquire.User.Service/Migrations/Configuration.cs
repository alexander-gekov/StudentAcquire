using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentAcquire.User.Service.Data;

namespace StudentAcquire.User.Service
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var context = app.ApplicationServices.CreateScope())
            {
                SeedData(context.ServiceProvider.GetService<UserServiceContext>(), isProd);
            }
        }

        private static void SeedData(UserServiceContext context, bool isProd)
        {
            if (isProd)
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

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new Models.User
                    {
                        Name = "Test user 1",
                        Username = "test_user_1",
                        Role = Enums.Role.SELLER,
                        Listings = new List<Models.Listing>() { new Models.Listing(1,1,"Test Listing 1", "Description for test listing 1")}
                    },
                   new Models.User
                   {
                       Name = "Test user 2",
                       Username = "test_user_2",
                       Role = Enums.Role.BUYER,
                       Listings = new List<Models.Listing>()
                   },
                    new Models.User
                    {
                        Name = "Test user 3",
                        Username = "test_user_3",
                        Role = Enums.Role.SELLER,
                        Listings = new List<Models.Listing>() { new Models.Listing(2, 2, "Test Listing 2", "Description for test listing 2") , new Models.Listing(3, 3, "Test Listing 3", "Description for test listing 3") }
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