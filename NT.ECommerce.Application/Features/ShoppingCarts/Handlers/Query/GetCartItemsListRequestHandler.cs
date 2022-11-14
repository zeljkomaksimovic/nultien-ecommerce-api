using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Handlers.Queries
{
    public class GetCartItemsListRequestHandler : IRequestHandler<GetCartItemsListRequest, List<ShoppingCartDto>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public GetCartItemsListRequestHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<List<ShoppingCartDto>> Handle(GetCartItemsListRequest request, CancellationToken cancellationToken)
        {
            var cartItemsList = await _shoppingCartRepository.GetAllAsync();
            return _mapper.Map<List<ShoppingCartDto>>(cartItemsList);
        }
    }
}
