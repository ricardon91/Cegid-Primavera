using AutoMapper;
using Customers.Application.Contracts.Persistence;
using Customers.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Commands.InsertCustomer
{
    public class InsertCustomerCommandHandler : IRequestHandler<InsertCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertCustomerCommandHandler> _logger;

        public InsertCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<InsertCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Customer>(request);
            var newCustomer = await _customerRepository.AddAsync(customerEntity);

            _logger.LogInformation($"Customer {newCustomer.Id} was successfully created.");

            return newCustomer.Id;
        }
    }
}
