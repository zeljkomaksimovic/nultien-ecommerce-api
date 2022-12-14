using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Product.Validators;
using NT.ECommerce.Application.Features.Products.Requests.Command;
using NT.ECommerce.Application.Responses;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            var validator = new CreateProductDtoValidator();
            var validate = await validator.ValidateAsync(request.CreateProductDto!);

            if (validate.IsValid is true)
            {
                var product = _mapper.Map<Product>(request.CreateProductDto!);
                product = await _productRepository.AddAsync(product);

                response.Success = true;
                response.Message = "Product is Successfuly created.";
                response.Id = product.Id;            
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create Product.";
                response.Errors = validate.Errors.Select(q => q.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
