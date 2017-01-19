using System.Web.Mvc;
using Stormpath.AspNet;
using Stormpath.AspNet.WebApi;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Controllers
{
    [Authorize]
    [StormpathGroupsRequired("admin")]
    [StormpathGroupsRequired("user")]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            var client = Request.GetStormpathClient();
            var account = Request.GetStormpathAccount();

            return View(new Profile {Account = account});
        }
    }
}