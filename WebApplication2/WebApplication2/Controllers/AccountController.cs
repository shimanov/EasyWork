using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebApplication2.Models.Identity;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
       private ApplicationUserManager UserManager
       {
           get
           {
               return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
           }
       }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(WebApplication2.Domain.Entities.User model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Generate token
                    //var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //Create link for confirm
                    //var callBack = Url.Action("", "Account", new
                    //{
                    //    userId = user.Id,
                    //    code = code
                    //}, protocol:Request.Url.Scheme);

                    await UserManager.AddToRoleAsync(user.Id, "User");

                    //Send email
                    //await
                    //    UserManager.SendEmailAsync(user.Id, "Подтверждение регистрации",
                    //        "для завершения регистрации перейдите по ссылке :: <a href=" + callBack +
                    //        "\">Завершить регистрацию</a>");
                    //return View("DisplayEmail");
                    
                    return RedirectToAction("", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Passord);
                if (user == null)
                {
                    ModelState.AddModelError("", "Не верный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claims =
                        await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claims);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Phones", "Default");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}