using NT.ECommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts
{
    public interface IAddProductToCartService
    {
        Task<AddToCartResponse> AddProduct(AddToCartRequest request);
    }
}
