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
    public class GetSalesCommandHandler : IRequestHandler<GetSalesQuery, List<SalesItemsVm>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;

        public GetSalesCommandHandler(ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<SalesItemsVm>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            var salesList = await _salesRepository.GetAllAsync();
            return _mapper.Map<List<SalesItemsVm>>(salesList);
        }
    }
}
