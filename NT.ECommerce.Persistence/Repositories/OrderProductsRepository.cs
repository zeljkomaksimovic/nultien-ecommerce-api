using Microsoft.EntityFrameworkCore;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence.Repositories
{
    public class OrderProductsRepository : IOrderProductsRepository
    {
        public OrderProductsRepository(NTECommerceDbContext dbContext) 
        {
        }
    }
}
