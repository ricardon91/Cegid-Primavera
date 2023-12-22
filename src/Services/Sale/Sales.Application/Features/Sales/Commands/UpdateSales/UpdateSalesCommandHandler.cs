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

namespace Sales.Application.Features.Sales.Commands.UpdateSales
{
    public class UpdateSalesCommandHandler : IRequestHandler<UpdateSalesCommand, Unit>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateSalesCommandHandler> _logger;

        public UpdateSalesCommandHandler(ISalesRepository salesRepository, IMapper mapper, ILogger<UpdateSalesCommandHandler> logger)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateSalesCommand request, CancellationToken cancellationToken)
        {
            var saleToUpdate = await _salesRepository.GetByIdAsync(request.Id);

            if (saleToUpdate == null)
            {
                throw new NotFoundException(nameof(SalesItems), request.Id);
            }

            _mapper.Map(request, saleToUpdate, typeof(UpdateSalesCommand), typeof(SalesItems));

            await _salesRepository.UpdateAsync(saleToUpdate);

            _logger.LogInformation($"Order {saleToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
