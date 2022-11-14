using MediatR;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Requests.Query
{
    public class GetCartRequest : IRequest<ShoppingCartDto>
    {
        public int Id { get; set; }
    }
}
