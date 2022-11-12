using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(NTECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
