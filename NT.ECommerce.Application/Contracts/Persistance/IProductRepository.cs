using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductAsync(int id, int quantity);
        Task<bool> ExistsAsync(int id);
    }
}
