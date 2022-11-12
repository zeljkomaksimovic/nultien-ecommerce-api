using Microsoft.EntityFrameworkCore;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly NTECommerceDbContext _dbContext;

        public CustomerRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Customers.AnyAsync(q => q.Id == id);
        }
    }
}
