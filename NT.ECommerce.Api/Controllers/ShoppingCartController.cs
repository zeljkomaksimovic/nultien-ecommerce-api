using MediatR;
using Microsoft.AspNetCore.Mvc;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Command;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Queries;
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

        [HttpGet]
        public async Task<ActionResult<List<ShoppingCartDto>>> AddAsync()
        {
            var response = await _mediator.Send(new GetCartItemsListRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CommandResponse>> AddAsync([FromBody] CreateShoppingCartDto createShoppingCartDto)
        {
            var response = await _mediator.Send(new CreateCartItemForCustomerCommand { CreateShoppingCartDto = createShoppingCartDto });
            return Ok(response);
        }
    }
}
