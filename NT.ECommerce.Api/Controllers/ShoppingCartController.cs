using MediatR;
using Microsoft.AspNetCore.Mvc;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Command;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Queries;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Query;
using NT.ECommerce.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NT.ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShoppingCartDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ShoppingCartDto>> GetAsync(int id)
        {
            var response = await _mediator.Send(new GetCartRequest {Id = id });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ShoppingCartDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet]
        public async Task<ActionResult<List<ShoppingCartDto>>> GetAllAsync()
        {
            var response = await _mediator.Send(new GetCartItemsListRequest());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CommandResponse>> AddAsync([FromBody] CreateShoppingCartDto createShoppingCartDto)
        {
            var response = await _mediator.Send(new CreateCartItemForCustomerCommand { CreateShoppingCartDto = createShoppingCartDto });
            return Ok(response);
        }
    }
}
