using AutoMapper;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.ViewComponents.Dashboard
{
    public class _DashboardNotificationListPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public _DashboardNotificationListPartial(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var notificationList = _notificationService.TGetList();
            var mapList=_mapper.Map<List<ListNotificationDto>>(notificationList);
            return View(mapList);
        }
    }
}
