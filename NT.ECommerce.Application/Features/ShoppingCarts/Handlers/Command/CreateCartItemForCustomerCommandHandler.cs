using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Command;
using NT.ECommerce.Application.Responses;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.ShoppingCarts.Handlers.Command
{
    public class CreateCartItemForCustomerCommandHandler : IRequestHandler<CreateCartItemForCustomerCommand, CommandResponse>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;

        public CreateCartItemForCustomerCommandHandler(
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<CommandResponse> Handle(CreateCartItemForCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            

            var productFromLocal = await _productRepository.GetProductAsync(request.CreateShoppingCartDto!.ProductId, request.CreateShoppingCartDto.Quantity);

            if (productFromLocal is not null)
            {
                response.Message = "Product is added to cart from local storage.";
            }
            else
            {
                var productFromSupplier = _supplierRepository.GetSupplierStocksOfProduct(request.CreateShoppingCartDto!.ProductId, request.CreateShoppingCartDto!.Quantity);
                if (productFromSupplier is not null)
                {
                    response.Message = "Product is added to cart from supplier stocks.";
                }
                else
                {
                    response.Success = false;
                    response.Id = request.CreateShoppingCartDto!.ProductId;
                    response.Message = "Product is not available.";

                    return response;
                }
            }

            var addedProduct = await _shoppingCartRepository.AddAsync(new ShoppingCart { 
                CustomerId = request.CreateShoppingCartDto.CustomerId, ProductId = request.CreateShoppingCartDto!.ProductId });

            if (addedProduct is not null)
            {
                response.Success = true;
                response.Id = request.CreateShoppingCartDto!.ProductId;
            }

            return response;
        }
    }
}
