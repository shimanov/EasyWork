using System.Web.Mvc;
using Stormpath.AspNet.WebApi;

namespace WebApplication2.Controllers
{
    [Authorize]
    [StormpathGroupsRequired("admin")]
    [StormpathGroupsRequired("user")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}