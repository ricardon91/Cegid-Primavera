using AutoMapper;
using Sales.Application.Features.Sales.Commands.InsertSales;
using Sales.Application.Features.Sales.Commands.UpdateSales;
using Sales.Application.Features.Sales.Queries;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalesItems, SalesItemsVm>().ReverseMap();
            CreateMap<SalesItems, InsertSalesCommand>().ReverseMap();
            CreateMap<SalesItems, UpdateSalesCommand>().ReverseMap();
        }
    }
}
