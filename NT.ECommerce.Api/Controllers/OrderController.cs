using MediatR;
using Microsoft.AspNetCore.Mvc;
using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.Features.Orders.Request.Command;
using NT.ECommerce.Application.Features.Orders.Request.Queries;
using NT.ECommerce.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NT.ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllAsync()
        {
            var orders = await _mediator.Send(new GetOrdersListRequest());
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<CommandResponse>> AddAsync([FromBody] CreateOrderDto createOrderDto)
        {
            var response = await _mediator.Send(new CreateOrderCommand { CreateOrderDto = createOrderDto });
            return Ok(response);
        }
    }
}
