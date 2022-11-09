using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
