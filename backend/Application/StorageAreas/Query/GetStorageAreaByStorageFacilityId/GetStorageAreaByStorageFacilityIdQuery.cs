using Application.Common.Models;
using Application.Persistence;
using Domain.Common.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.StorageAreas.Query.GetStorageAreaByStorageFacilityId
{
    public class GetStorageAreaByStorageFacilityIdQuery : IRequest<Result<List<StorageAreaDto>>>
    {
        public Guid StorageFacilityId { get; set; }
    }

    public class GetStorageAreaQueryHandler : IRequestHandler<GetStorageAreaByStorageFacilityIdQuery, Result<List<StorageAreaDto>>>
    {
        private readonly IAppDbContext _context;
        public GetStorageAreaQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<StorageAreaDto>>> Handle(GetStorageAreaByStorageFacilityIdQuery request, CancellationToken cancellationToken)
        {
            if(Guid.Empty == request.StorageFacilityId)
                return Result<List<StorageAreaDto>>.Error("StorageFacilityId is required.");

            var storageAreas = await _context.StorageAreas
                .Select(x => new StorageAreaDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    StorageAreaTypeId = x.StorageAreaTypeId,
                    StorageFacilityId = x.StorageFacilityId,
                    TotalSpace = x.TotalSpace,
                    RemainingSpace = x.TotalSpace - x.CustomerBoxes.Count(x => x.BoxStatusId == new Guid(BoxStatuses.Stored))
                })
                .Where(x => x.StorageFacilityId == request.StorageFacilityId)
                .ToListAsync(cancellationToken);

            return Result<List<StorageAreaDto>>.Ok(storageAreas);
        }
    }
}
