using Application.Common.Models;
using Application.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.StorageFacilities.Query.GetStorageAreas
{
    public class GetStorageFacilitiesFacilitiesQuery : IRequest<Result<List<StorageFacility>>>
    {
    }

    public class GetStorageFacilitiesFacilitiesQueryHandler : IRequestHandler<GetStorageFacilitiesFacilitiesQuery, Result<List<StorageFacility>>>
    {
        private readonly IAppDbContext _context;
        public GetStorageFacilitiesFacilitiesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<StorageFacility>>> Handle(GetStorageFacilitiesFacilitiesQuery request, CancellationToken cancellationToken)
        {
            return Result<List<StorageFacility>>.Ok(await _context.StorageFacilities.ToListAsync(cancellationToken));
        }
    }
}
