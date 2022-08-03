using Application.Common.Models;
using Application.Customers.Commands.AddCustomer;
using Application.Customers.Commands.AddCustomerBox;
using Application.Customers.Commands.RemoveCustomerBox;
using Application.Customers.Query.GetCustomers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace frontedesk.Controllers
{
    [Route("api/customers")]
    public class CustomersController : BaseController
    {
        public CustomersController(ISender sender) 
            : base(sender)
        {
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<Customer>>>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _sender.Send(new GetCustomersQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<Result<Guid>>> CreateAsync(
            [FromBody] AddCustomerCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command == null)
                return BadRequest(Result<Guid>.Error("Invalid request body."));

            var result = await _sender.Send(command, cancellationToken);

            if (!result.IsSuccess)
            {
                if(result.StatusCode == (int)HttpStatusCode.BadRequest)
                    return BadRequest(result);

                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                    return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost("{customerId}/boxes")]
        public async Task<ActionResult<Result<Guid>>> AddBoxAsync(
            Guid customerId,
            [FromBody] AddCustomerBoxCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command == null)
                return BadRequest(Result<Guid>.Error("Invalid request body."));

            command.CustomerId = customerId;
            var result = await _sender.Send(command, cancellationToken);

            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.BadRequest)
                    return BadRequest(result);

                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                    return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{customerId}/boxes/{boxId}")]
        public async Task<ActionResult<Result<bool>>> RemoveBoxAsync(
            Guid customerId,
            Guid boxId,
            [FromBody] RemoveCustomerBoxCommand command,
            CancellationToken cancellationToken = default)
        {
            if (command == null)
                return BadRequest(Result<bool>.Error("Invalid request body."));

            command.CustomerId = customerId;
            command.BoxId = boxId;
            var result = await _sender.Send(command, cancellationToken);

            if (!result.IsSuccess)
            {
                if (result.StatusCode == (int)HttpStatusCode.BadRequest)
                    return BadRequest(result);

                if (result.StatusCode == (int)HttpStatusCode.NotFound)
                    return NotFound(result);
            }

            return Ok(result);
        }
    }
}