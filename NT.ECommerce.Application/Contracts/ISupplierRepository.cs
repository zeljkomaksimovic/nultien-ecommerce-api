using NT.ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Contracts
{
    public interface ISupplierRepository
    {
        ProductDto GetSupplierStocksOfProduct(int id, int quantity);
    }
}
