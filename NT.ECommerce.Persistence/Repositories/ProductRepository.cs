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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly NTECommerceDbContext _dbContext;

        public ProductRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetProductAsync(int id, int quantity)
        {
            var product = await _dbContext.Products.Where(x => x.Id == id && x.Quantity >= quantity).FirstOrDefaultAsync();
            return product!;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Products.AnyAsync(q => q.Id == id);
        }
    }
}
