using MediatR;
using Microsoft.AspNetCore.Mvc;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Features.Products.Requests.Command;
using NT.ECommerce.Application.Features.Products.Requests.Query;
using NT.ECommerce.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NT.ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllAsync()
        {
            var customers = await _mediator.Send(new GetProductsListRequest());
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<CommandResponse>> AddAsync([FromBody] CreateProductDto createProductDto)
        {
            var response = await _mediator.Send(new CreateProductCommand { CreateProductDto = createProductDto });
            return Ok(response);
        }
    }
}
