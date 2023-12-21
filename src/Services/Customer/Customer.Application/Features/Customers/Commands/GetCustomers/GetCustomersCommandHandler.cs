using AutoMapper;
using Customers.Application.Contracts.Persistence;
using Customers.Application.Features.Customers.Commands.DeleteCustomer;
using Customers.Application.Features.Customers.Queries;
using Customers.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Commands.GetCustomers
{
    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersQuery, List<CustomersVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CustomersVm>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customersList = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomersVm>>(customersList);
        }
    }
}
