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

namespace Customers.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToUpdate == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            await _customerRepository.UpdateAsync(customerToUpdate);

            _logger.LogInformation($"Customer {customerToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
