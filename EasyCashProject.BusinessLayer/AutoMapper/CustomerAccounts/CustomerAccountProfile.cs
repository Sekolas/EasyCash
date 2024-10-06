n  using AutoMapper;
using EasyCashProject.DtoLayer.Dtos.CustomerAccountDtos;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.AutoMapper.CustomerAccounts
{
    public class CustomerAccountProfile : Profile
    {
        public CustomerAccountProfile()
        {
            CreateMap<CustomerAccount, CreateAccountDto>().ReverseMap();
            CreateMap<CustomerAccount, ListCustomerAccountDto>().ReverseMap();
        }
    }
}
