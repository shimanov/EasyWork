using System.Linq;
using System.Web.Mvc;
using WebApplication.Service.Services.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        private IPhoneBookService _phoneBookService = null;

        public DefaultController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        public ActionResult Phones()
        {
            var phones = _phoneBookService.GetPhoneBooks()
                .Select(x => new PhoneBook
                {
                    Id = x.Id,
                    Fio = x.Fio,
                    IsDeleted = x.IsDeleted,
                    PhoneNumber = x.PhoneNumber,
                    Pochtamt = x.Pochtamt
                }).ToArray();

            return View(phones);
        }

        [HttpGet]
        public ActionResult DeletePhone(int id)
        {
            _phoneBookService.DeletePhone(id);
            return RedirectToAction("Phones");
        }

        [HttpGet]
        public ActionResult RestorePhone(int id)
        {
            _phoneBookService.RestorePhone(id);
            return RedirectToAction("Phones");
        }

        [HttpGet]
        public ActionResult AddPhone()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhone(PhoneBook phone)
        {
            _phoneBookService.AddPhone(new PhoneBook
            {
                Fio = phone.Fio,
                Id = phone.Id,
                IsDeleted = false,
                PhoneNumber = phone.PhoneNumber,
                Pochtamt = phone.Pochtamt
            });
            return RedirectToAction("Phones");
        }

        [HttpGet]
        public ActionResult EditPhone(int id)
        {
            var phone = _phoneBookService.GetPhoneBooks()
                .FirstOrDefault(x => x.Id == id);

            return View(new PhoneBook
            {
                Id = phone.Id,
                Fio = phone.Fio,
                IsDeleted = phone.IsDeleted,
                PhoneNumber = phone.PhoneNumber,
                Pochtamt = phone.Pochtamt
            });
        }

        [HttpPost]
        public ActionResult EditPhone(PhoneBook phone)
        {
            _phoneBookService.EditPhone(new PhoneBook
            {
                Fio = phone.Fio,
                Id = phone.Id,
                IsDeleted = false,
                PhoneNumber = phone.PhoneNumber,
                Pochtamt = phone.Pochtamt
            });
            return RedirectToAction("Phones");
        }
    }
}