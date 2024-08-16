using AutoMapper;
using EasyCashProject.DtoLayer.Dtos.ContactDtos;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.AutoMapper.Contacts
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
        }
    }
}
