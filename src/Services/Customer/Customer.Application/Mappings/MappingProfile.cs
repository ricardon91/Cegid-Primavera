using AutoMapper;
using Customers.Application.Features.Customers.Commands.InsertCustomer;
using Customers.Application.Features.Customers.Commands.UpdateCustomer;
using Customers.Application.Features.Customers.Queries;
using Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomersVm>().ReverseMap();
            CreateMap<Customer, InsertCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }        
    }
}
