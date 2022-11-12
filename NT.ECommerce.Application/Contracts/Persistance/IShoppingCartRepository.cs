using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts.Persistance
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
        Task<List<ShoppingCart>> GetCustomerCartItems(int customerId);
        Task EmptyShoppingCart(List<ShoppingCart> shoppingCarts);
    }
}
