using Application.Common.Models;
using Application.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Query.GetCustomerBoxes
{
    public class GetCustomerBoxesQuery : IRequest<Result<List<CustomerBox>>> // ideally you shouldn't return the domain model
    {
        public Guid CustomerId { get; set; }
    }

    public class GetCustomerBoxesQueryHandler : IRequestHandler<GetCustomerBoxesQuery, Result<List<CustomerBox>>>
    {
        private readonly IAppDbContext _context;
        public GetCustomerBoxesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<CustomerBox>>> Handle(GetCustomerBoxesQuery request, CancellationToken cancellationToken)
        {
            if (request.CustomerId == Guid.Empty)
                return Result<List<CustomerBox>>.Error("CustomerId is required.");

            return Result<List<CustomerBox>>.Ok(await _context.CustomerBoxes.Where(x => x.CustomerId == request.CustomerId).ToListAsync(cancellationToken));
        }
    }
}
