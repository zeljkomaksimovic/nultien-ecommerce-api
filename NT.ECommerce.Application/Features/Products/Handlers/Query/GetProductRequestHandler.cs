using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Features.Products.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Products.Handlers.Query
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(request.Id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
