using AutoMapper;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var notificationList = _notificationService.TGetList();
            var mapList = _mapper.Map<List<ListNotificationDto>>(notificationList);
            return View(mapList);
        }

        public IActionResult GetById(int notificationId)
        {
            var notification = _notificationService.TGetByID(notificationId);
            var mapValue = _mapper.Map<ListNotificationDto>(notification);
            return View(mapValue);
        }
    }
}
