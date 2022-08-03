using Application.Common.Models;
using Application.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BoxTypes.Query.GetBoxTypes
{
    public class GetBoxTypesQuery : IRequest<Result<List<BoxType>>>
    {
    }

    public class GetBoxTypesQueryHandler : IRequestHandler<GetBoxTypesQuery, Result<List<BoxType>>>
    {
        private readonly IAppDbContext _context;
        public GetBoxTypesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<BoxType>>> Handle(GetBoxTypesQuery request, CancellationToken cancellationToken)
        {
            return Result<List<BoxType>>.Ok(await _context.BoxTypes.ToListAsync(cancellationToken));
        }
    }
}
