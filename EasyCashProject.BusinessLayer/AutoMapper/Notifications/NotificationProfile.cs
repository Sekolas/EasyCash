using AutoMapper;
using EasyCashProject.DtoLayer.Dtos.NotificationDtos;
using EasyCashProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashProject.BusinessLayer.AutoMapper.Notifications
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, ListNotificationDto>().ReverseMap();
        }
    }
}
