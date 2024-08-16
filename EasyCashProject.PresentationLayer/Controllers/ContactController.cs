using AutoMapper;
using EasyCashProject.BusinessLayer.Abstract;
using EasyCashProject.DtoLayer.Dtos.ContactDtos;
using EasyCashProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashProject.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateContactDto createContactDto)
        {
            var mapContact = _mapper.Map<Contact>(createContactDto);
            _contactService.TInsert(mapContact);
            return RedirectToAction("Index", "Home");
        }
    }
}
