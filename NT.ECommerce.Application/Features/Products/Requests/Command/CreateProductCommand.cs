using MediatR;
using NT.ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Products.Requests.Command
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDto? CreateProductDto { get; set; }
    }
}
