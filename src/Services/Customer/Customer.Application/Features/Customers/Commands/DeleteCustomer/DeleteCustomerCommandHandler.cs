using AutoMapper;
using Customers.Application.Contracts.Persistence;
using Customers.Application.Exceptions;
using Customers.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            await _customerRepository.DeleteAsync(customerToDelete);

            _logger.LogInformation($"Customer {customerToDelete.Id} was successfully deleted.");

            return Unit.Value;
        }
    }
}
