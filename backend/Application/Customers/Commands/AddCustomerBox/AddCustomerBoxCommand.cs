using Application.Common.Models;
using Application.Persistence;
using Domain.Common.Constants;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.AddCustomerBox
{
    public class AddCustomerBoxCommand : IRequest<Result<Guid>>
    {
        public Guid CustomerId { get; set; }
        public string Label { get; set; }
        public Guid BoxTypeId { get; set; }
        public Guid StorageAreaId { get; set; }
    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerBoxCommand, Result<Guid>>
    {
        private readonly IAppDbContext _context;
        public AddCustomerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(AddCustomerBoxCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Label))
                return Result<Guid>.Error("Label is required.");

            if (Guid.Empty == request.CustomerId)
                return Result<Guid>.Error("CustomerId is required.");

            if (Guid.Empty == request.StorageAreaId)
                return Result<Guid>.Error("StorageAreaId is required.");

            if (Guid.Empty == request.BoxTypeId)
                return Result<Guid>.Error("BoxTypeId is required.");

            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);
            if (customer == null)
                return Result<Guid>.NotFound($"Invalid customer id '{request.CustomerId}'");

            var storageArea = await _context.StorageAreas.SingleOrDefaultAsync(x => x.Id == request.StorageAreaId, cancellationToken);
            if (storageArea == null)
                return Result<Guid>.Error("StorageAreaId is invalid.");

            var totalBoxes = await _context.StorageAreas.Where(x => x.Id == request.StorageAreaId).Select(x => x.CustomerBoxes.Count).SingleAsync(cancellationToken);
            if (totalBoxes >= storageArea.TotalSpace)
                return Result<Guid>.Error($"Storage area '{storageArea.Name}' is full.");

            var boxType = await _context.BoxTypes.SingleOrDefaultAsync(x => x.Id == request.BoxTypeId, cancellationToken);
            if (boxType == null)
                return Result<Guid>.Error("BoxTypeId is invalid.");

            if(boxType.Name != storageArea.Name) // stick with this for now :)
                return Result<Guid>.Error($"Box type '{boxType.Name}' is not allowed to be stored in this area.");


            var box = new CustomerBox
            {
                Label = request.Label,
                StorageAreaId = request.StorageAreaId,
                BoxStatusId = Guid.Parse(BoxStatuses.Stored)
            };
            
            customer.Boxes.Add(box);
            _context.StorageAreaHistory.Add(new StorageAreaHistory
            {
                StorageAreaId = storageArea.Id,
                CustomerBoxId = customer.Id,
                DateTime = DateTime.Now,
                Action = nameof(BoxStatuses.Stored)
            });

            if (await _context.SaveChangesAsync(cancellationToken) < 1)
                return Result<Guid>.Error("We are unable to process your request at the moment.");

            return Result<Guid>.Ok(box.Id);
        }
    }
}
