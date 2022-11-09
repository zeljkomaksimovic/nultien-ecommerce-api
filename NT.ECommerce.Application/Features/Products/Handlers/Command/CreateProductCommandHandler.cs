using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.Product.Validators;
using NT.ECommerce.Application.Features.Products.Requests.Command;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductDtoValidator();
            var validate = await validator.ValidateAsync(request.CreateProductDto!);

            if (validate.IsValid is false)
            {
                throw new Exception();
            }

            var product = _mapper.Map<Product>(request.CreateProductDto!);
            product = await _productRepository.Add(product);

            return product.Id;
        }
    }
}
