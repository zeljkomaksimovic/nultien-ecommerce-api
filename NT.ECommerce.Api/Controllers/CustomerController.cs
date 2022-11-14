using MediatR;
using Microsoft.AspNetCore.Mvc;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.Features.Customers.Requests.Command;
using NT.ECommerce.Application.Features.Customers.Requests.Query;
using NT.ECommerce.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NT.ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerDto>>> GetAsync(int id)
        {
            var customers = await _mediator.Send(new GetCustomerRequest { Id = id});
            return Ok(customers);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]     
        public async Task<ActionResult<List<CustomerDto>>> GetAllAsync()
        {
            var customers = await _mediator.Send(new GetCustomersListRequest());
            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]      
        public async Task<ActionResult<CommandResponse>> AddAsync([FromBody] CreateCustomerDto createCustomerDto)
        {
            var response = await _mediator.Send(new CreateCustomerCommand { CreateCustomerDto = createCustomerDto });
            return Ok(response);
        }
    }
}
