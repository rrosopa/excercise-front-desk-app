using Application.Common.Models;
using Application.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.StorageFacilities.Query.StorageFacilityAreaSummary
{
    public class StorageFacilityAreaSummaryQuery : IRequest<Result<List<StorageFacilityAreaSummaryDto>>>
    {
    }

    public class StorageFacilityAreaSummaryQueryHandler : IRequestHandler<StorageFacilityAreaSummaryQuery, Result<List<StorageFacilityAreaSummaryDto>>>
    {
        private readonly IAppDbContext _context;
        public StorageFacilityAreaSummaryQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<StorageFacilityAreaSummaryDto>>> Handle(StorageFacilityAreaSummaryQuery request, CancellationToken cancellationToken)
        {
            var summary = await _context.StorageAreas
                .Select(x => new StorageFacilityAreaSummaryDto
                {
                    StorageAreaId = x.Id,
                    StorageAreaName = x.Name,
                    TotalCapacity = x.TotalSpace,
                    RemainingCapacity = x.TotalSpace - x.CustomerBoxes.Count(),
                    StorageFacilityId = x.StorageFacilityId,
                    StorageFacilityName = x.StorageFacility.Name
                })
                .ToListAsync(cancellationToken);

            return Result<List<StorageFacilityAreaSummaryDto>>.Ok(summary);
        }
    }
}
