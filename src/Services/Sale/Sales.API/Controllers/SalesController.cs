using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Application.Features.Sales.Commands.DeleteSales;
using Sales.Application.Features.Sales.Commands.InsertSales;
using Sales.Application.Features.Sales.Commands.UpdateSales;
using Sales.Application.Features.Sales.Queries;
using System.Net;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetSales")]
        [ProducesResponseType(typeof(IEnumerable<SalesItemsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SalesItemsVm>>> GetSales()
        {
            var query = new GetSalesQuery();
            var sales = await _mediator.Send(query);
            return Ok(sales);
        }

        [HttpGet("{id}", Name = "GetSaleById")]
        [ProducesResponseType(typeof(SalesItemsVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<SalesItemsVm>> GetSaleById(int id)
        {
            var query = new GetSaleByIdQuery(id);
            var sale = await _mediator.Send(query);
            return Ok(sale);
        }

        [HttpPost(Name = "InsertSale")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> InsertSale([FromBody] InsertSalesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateSale")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSale([FromBody] UpdateSalesCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteSale")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSale(int id)
        {
            var command = new DeleteSalesCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
