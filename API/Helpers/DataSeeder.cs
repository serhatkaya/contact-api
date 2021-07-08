using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Infrastructure;
using Domain.Entities;
using Infrastructure.Extensions;

namespace API.Helpers
{
    public class DataSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    ContactContext masterContext = scope.ServiceProvider.GetRequiredService<ContactContext>();
                    masterContext.Database.Migrate();

                    if (!masterContext.Users.Where(x => true).Any())
                    {
                        masterContext.Users.Add(new User()
                        {
                            Username = "root@serhatkaya.com.tr",
                            Name = "Serhat KAYA",
                            Role = "Admin",
                            Password = "serhatkaya".GetMD5()
                        });
                    }

                    masterContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Inner exception: {ex.InnerException}");
                }
            }
        }
    }
}