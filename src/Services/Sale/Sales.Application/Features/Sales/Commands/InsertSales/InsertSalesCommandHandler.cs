using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Features.Sales.Commands.DeleteSales;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.InsertSales
{
    public class InsertSalesCommandHandler : IRequestHandler<InsertSalesCommand, int>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertSalesCommandHandler> _logger;

        public InsertSalesCommandHandler(ISalesRepository salesRepository, IMapper mapper, ILogger<InsertSalesCommandHandler> logger)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(InsertSalesCommand request, CancellationToken cancellationToken)
        {
            var salesEntity = _mapper.Map<SalesItems>(request);
            var newSales = await _salesRepository.AddAsync(salesEntity);

            _logger.LogInformation($"Sale {newSales.Id} was successfully created.");

            return newSales.Id;
        }
    }
}
