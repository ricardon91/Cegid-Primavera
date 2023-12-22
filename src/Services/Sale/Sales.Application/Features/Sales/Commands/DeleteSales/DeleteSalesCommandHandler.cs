using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Exceptions;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.DeleteSales
{
    public class DeleteSalesCommandHandler : IRequestHandler<DeleteSalesCommand, Unit>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteSalesCommandHandler> _logger;

        public DeleteSalesCommandHandler(ISalesRepository salesRepository, IMapper mapper, ILogger<DeleteSalesCommandHandler> logger)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
        {
            var saleToDelete = await _salesRepository.GetByIdAsync(request.Id);

            if (saleToDelete == null)
            {
                throw new NotFoundException(nameof(SalesItems), request.Id);
            }

            await _salesRepository.DeleteAsync(saleToDelete);

            _logger.LogInformation($"Sale {saleToDelete.Id} was successfully deleted.");

            return Unit.Value;
        }
    }
}
