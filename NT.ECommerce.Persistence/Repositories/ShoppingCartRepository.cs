using Microsoft.EntityFrameworkCore;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly NTECommerceDbContext _dbContext;

        public ShoppingCartRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
     
        public async Task<List<ShoppingCart>> GetCustomerCartItems(int customerId)
        {
            return await _dbContext.ShoppingCarts
                .Where(q => q.CustomerId == customerId)
                .Include(q => q.Product)             
                .ToListAsync();
        }

        public async Task EmptyShoppingCart(List<ShoppingCart> shoppingCarts)
        {
             _dbContext.ShoppingCarts.RemoveRange(shoppingCarts);
            await _dbContext.SaveChangesAsync();
        }

    }
}
