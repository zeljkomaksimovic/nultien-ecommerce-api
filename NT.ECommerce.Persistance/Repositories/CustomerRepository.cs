using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistance.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
