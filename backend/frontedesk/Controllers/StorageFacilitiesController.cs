using Application.Common.Models;
using Application.StorageAreas.Query.GetStorageAreaByStorageFacilityId;
using Application.StorageFacilities.Query.GetStorageAreas;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace frontedesk.Controllers
{
    [Route("api/storage-facilities")]
    public class StorageFacilitiesController : BaseController
    {
        public StorageFacilitiesController(ISender sender) 
            : base(sender)
        {
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<StorageFacility>>>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _sender.Send(new GetStorageFacilitiesFacilitiesQuery(), cancellationToken));
        }

        [HttpGet("{storageFacilityId}/areas")]
        public async Task<ActionResult<Result<List<StorageAreaDto>>>> GetAreasListAsync(
            Guid storageFacilityId,
            CancellationToken cancellationToken = default)
        {
            var result = await _sender.Send(new GetStorageAreaByStorageFacilityIdQuery
            {
                StorageFacilityId = storageFacilityId
            }, cancellationToken);

            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}