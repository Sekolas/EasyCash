using AutoMapper;
using EasyCashProject.DtoLayer.Dtos.CreditCardDtos;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.AutoMapper.CreditCards
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCard, ListCreditCardDto>().ReverseMap();
        }
    }
}
