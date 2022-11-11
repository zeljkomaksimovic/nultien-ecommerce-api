using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistance.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly NTECommerceDbContext _dbContext;

        public CustomerRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedCustomerData()
        {
            await _dbContext.Database.EnsureCreatedAsync();

            var customers = new[]
            {
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
            };


            await _dbContext.AddRangeAsync(customers);

            await _dbContext.SaveChangesAsync();
        }
    }
}
