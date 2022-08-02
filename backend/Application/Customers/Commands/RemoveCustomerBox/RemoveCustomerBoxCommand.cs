using Application.Common.Models;
using Application.Persistence;
using Domain.Common.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.RemoveCustomerBox
{
    public class RemoveCustomerBoxCommand : IRequest<Result<bool>>
    {
        public Guid CustomerId { get; set; }
        public Guid BoxId { get; set; }
    }

    public class RemoveCustomerBoxCommandHandler : IRequestHandler<RemoveCustomerBoxCommand, Result<bool>>
    {
        private readonly IAppContext _context;
        public RemoveCustomerBoxCommandHandler(IAppContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> Handle(RemoveCustomerBoxCommand request, CancellationToken cancellationToken)
        {
            if (Guid.Empty == request.CustomerId)
                return Result<bool>.Error("CustomerId is required.");

            if (Guid.Empty == request.BoxId)
                return Result<bool>.Error("BoxId is required.");

            var customer = await _context.Customers
                                .Include(x => x.Boxes)
                                .SingleOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);

            if (customer == null)
                return Result<bool>.NotFound($"Invalid customer id '{request.CustomerId}'");

            var box = customer.Boxes.SingleOrDefault(x => x.Id == request.BoxId);
            if (box == null)
                return Result<bool>.NotFound("Invalid box id.");
            
            customer.Boxes.Remove(box);
            _context.StorageAreaHistory.Add(new StorageAreaHistory
            {
                StorageAreaId = box.StorageAreaId,
                CustomerBoxId = customer.Id,
                DateTime = DateTime.Now,
                Action = nameof(BoxStatuses.Retreived)
            });
            // savesync here

            return Result<bool>.Ok(true);
        }
    }
}
