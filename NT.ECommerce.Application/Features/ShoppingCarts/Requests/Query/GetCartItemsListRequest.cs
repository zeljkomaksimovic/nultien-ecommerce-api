using MediatR;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Requests.Queries
{
    public class GetCartItemsListRequest : IRequest<List<ShoppingCartDto>>
    {
    }
}
