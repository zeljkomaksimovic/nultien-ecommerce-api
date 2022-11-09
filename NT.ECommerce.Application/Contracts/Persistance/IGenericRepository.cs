using NT.ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<CustomerDto>> GetAll();
        Task<T> Add(T entity);
    }
}
