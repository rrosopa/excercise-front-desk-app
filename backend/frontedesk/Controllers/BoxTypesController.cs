using Application.BoxTypes.Query.GetBoxTypes;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace frontedesk.Controllers
{
    [Route("api/box-types")]
    public class BoxTypesController : BaseController
    {
        public BoxTypesController(ISender sender) 
            : base(sender)
        {
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<BoxType>>>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _sender.Send(new GetBoxTypesQuery(), cancellationToken));
        }
    }
}