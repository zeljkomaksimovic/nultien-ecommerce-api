using MediatR;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Requests.Command
{
    public class CreateCartItemForCustomerCommand : IRequest<CommandResponse>
    {
        public CreateShoppingCartDto? CreateShoppingCartDto { get; set; }
    }
}
