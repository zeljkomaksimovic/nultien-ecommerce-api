using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.ShoppingCart.Validators;
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
        private readonly ICustomerRepository _customerRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateCartItemForCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(CreateCartItemForCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            var validator = new CreateShoppingCartDtoValidator(_customerRepository, _productRepository);
            var validationResult = await validator.ValidateAsync(request.CreateShoppingCartDto!);

            if (validationResult.IsValid is true)
            {
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
                var shoppingCart = _mapper.Map<ShoppingCart>(request.CreateShoppingCartDto);

                var addedProduct = await _shoppingCartRepository.AddAsync(shoppingCart);

                if (addedProduct is not null)
                {
                    response.Success = true;
                    response.Id = request.CreateShoppingCartDto!.ProductId;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create Shopping cart.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
