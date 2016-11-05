using System.Linq;
using System.Web.Mvc;
using WebApplication.Service.Services.Base;
using WebApplication2.Areas.Admin.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService _adminService = null;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var IsAdmin = _adminService.UserInGroup
                (User.Identity.Name, "Administrators");

            if (IsAdmin)
                return View(IsAdmin);

            return RedirectToAction("ProblemDecision", "ProblemDecision", new {area = ""});
        }

        public ActionResult Users()
        {
            var users = _adminService.GetUsers().Select(x => new User
            {
                Id = x.Id,
                GroupId = x.GroupId.ToString(),
                Name = x.Name,
                Password = x.Password,
                IsDeleted = x.IsDeleted,
                GroupName = x.Group.Name
            }).ToArray();

            return View(users);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            _adminService.DeleteUser(id);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult RestoreUser(int id)
        {
            _adminService.DeleteUser(id);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(int id)
        {
            var user = _adminService.GetUsers().FirstOrDefault(x => x.Id == id);

            return View(new WebApplication2.Areas.Admin.Models.User
            {
                Id = user.Id,
                GroupId = user.GroupId.ToString(),
                Name = user.Name,
                Password = "",
                IsDeleted = user.IsDeleted,
                GroupName = user.Group.Name
            });
        }

        [HttpPost]
        public ActionResult EditUser([System.Web.Http.FromBody] WebApplication2.Areas.Admin.Models.User user)
        {
            _adminService.EditUser(new Domain.Entities.User
            {
                GroupId = int.Parse(user.GroupId),
                IsDeleted = false,
                Name = user.Name,
                Password = user.Password
            });
            return RedirectToAction("Users");
        }

        public ActionResult Groups()
        {
            var groups = _adminService.GetGroups();
            return View(groups);
        }

        /*
        [HttpGet]
        public ActionResult DeleteGroup(int id)
        { }

        [HttpGet]
        public ActionResult RestoreGroup(int id)
        { }
        
        [HttpGet]
        public ActionResult AddGroup()
        { }

        [HttpPost]
        public ActionResult AddGroup(int id)
        { }*/
    }
}