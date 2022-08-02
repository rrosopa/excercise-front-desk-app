using Application.Common.Models;
using Application.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.AddCustomer
{
    public class AddCustomerCommand : IRequest<Result<Guid>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Result<Guid>>
    {
        private readonly IAppContext _context;
        public AddCustomerCommandHandler(IAppContext context)
        {
            _context = context;
        }

        public async Task<Result<Guid>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FirstName))
                return Result<Guid>.Error("FirstName is required.");

            if (string.IsNullOrEmpty(request.LastName))
                return Result<Guid>.Error("LastName is required.");

            if (string.IsNullOrEmpty(request.PhoneNumber))
                return Result<Guid>.Error("PhoneNumber is required.");

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            _context.Customers.Add(customer);
            // save async here

            return Result<Guid>.Ok(customer.Id);
        }
    }
}
