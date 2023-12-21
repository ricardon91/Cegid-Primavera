using Customers.Application.Features.Customers.Commands.DeleteCustomer;
using Customers.Application.Features.Customers.Commands.InsertCustomer;
using Customers.Application.Features.Customers.Commands.UpdateCustomer;
using Customers.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Customers.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(typeof(IEnumerable<CustomersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomersVm>>> GetCustomers()
        {
            var query = new GetCustomersQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(CustomersVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomersVm>> GetCustomer(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpPost(Name = "InsertCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> InsertCustomer([FromBody] InsertCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
