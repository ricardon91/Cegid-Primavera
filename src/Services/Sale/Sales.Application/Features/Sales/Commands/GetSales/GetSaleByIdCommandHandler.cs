using AutoMapper;
using MediatR;
using Sales.Application.Contracts.Persistence;
using Sales.Application.Features.Sales.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.GetSales
{
    public class GetSaleByIdCommandHandler : IRequestHandler<GetSaleByIdQuery, SalesItemsVm>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public GetSaleByIdCommandHandler(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SalesItemsVm> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var sale = await _salesRepository.GetByIdAsync(request.Id);
            return _mapper.Map<SalesItemsVm>(sale);
        }
    }
}
