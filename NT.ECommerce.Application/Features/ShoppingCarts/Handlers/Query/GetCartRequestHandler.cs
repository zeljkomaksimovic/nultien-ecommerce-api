using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Handlers.Query
{
    public class GetCartRequestHandler : IRequestHandler<GetCartRequest, ShoppingCartDto>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public GetCartRequestHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartDto> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await _shoppingCartRepository.GetAsync(request.Id);
            return _mapper.Map<ShoppingCartDto>(cartItem);
        }
    }
}
