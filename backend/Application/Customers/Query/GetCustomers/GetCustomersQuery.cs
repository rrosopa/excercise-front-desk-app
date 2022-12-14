using Application.Common.Models;
using Application.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Query.GetCustomers
{
    public class GetCustomersQuery : IRequest<Result<List<Customer>>> // ideally you shouldn't return the domain model
    {
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, Result<List<Customer>>>
    {
        private readonly IAppDbContext _context;
        public GetCustomersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                                .ToListAsync(cancellationToken);

            return Result<List<Customer>>.Ok(customers);
        }
    }
}
