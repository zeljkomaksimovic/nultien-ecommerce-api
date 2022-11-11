using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistance.Services
{
    public static class SeedData
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var dbContext = new NTECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<NTECommerceDbContext>>()))
            {
                await dbContext.Database.EnsureCreatedAsync();

                if (dbContext.Customers.Any() is false)
                {
                    await dbContext.Customers.AddRangeAsync
                    (
                         new Customer
                         {
                             Id = 1,
                             FirstName = "Marko",
                             LastName = "Markovic",
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                         new Customer
                         {
                             Id = 2,
                             FirstName = "Stefan",
                             LastName = "Milosevic",
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         }
                     );
                }

                if (dbContext.Customers.Any() is false)
                {
                    await dbContext.Products.AddRangeAsync
                    (
                         new Product
                         {
                             Id = 1,
                             Name = "Hoodie",
                             Quantity = 2,
                             UnitPrice = 2490.90m,
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                        new Product
                        {
                            Id = 2,
                            Name = "T-Shirt",
                            Quantity = 2,
                            UnitPrice = 1390.90m,
                            CreatedBy = "zmaksimovic",
                            DateCreated = DateTime.Now,
                            Status = true
                        }
                    );
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
