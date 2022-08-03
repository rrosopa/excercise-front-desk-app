using Application.Common.Models;
using Application.Persistence;
using Domain.Common.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Query.GetCustomerBoxes
{
    public class GetCustomerBoxesQuery : IRequest<Result<List<CustomerBoxDto>>> // ideally you shouldn't return the domain model
    {
        public Guid CustomerId { get; set; }        
    }

    public class GetCustomerBoxesQueryHandler : IRequestHandler<GetCustomerBoxesQuery, Result<List<CustomerBoxDto>>>
    {
        private readonly IAppDbContext _context;
        public GetCustomerBoxesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<CustomerBoxDto>>> Handle(GetCustomerBoxesQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerId == Guid.Empty)
                return Result<List<CustomerBoxDto>>.Error("CustomerId is required.");

            var boxes = await _context.CustomerBoxes
                .Where(x => x.CustomerId == request.CustomerId && x.BoxStatusId == new Guid(BoxStatuses.Stored))
                .Select(x => new CustomerBoxDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    Label = x.Label,
                    StorageAreaName = x.StorageArea.Name,
                    StorageFacility = x.StorageArea.StorageFacility.Name
                })
                .ToListAsync(cancellationToken);

            return Result<List<CustomerBoxDto>>.Ok(boxes);
        }
    }
}
