using System;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Service.Services.Base;
using WebApplication2.Models.Authentication;

namespace WebApplication2.Controllers
{
    public class AuthencationController : Controller
    {
        IAuthenticationService _authenticationService = null;

        public AuthencationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public ActionResult Index()
        {
            return View(new User
            {
                IsAuth = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name
            });
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Authencation");
        }

        [HttpGet]
        [ActionName("LogIn")]
        public ActionResult LogIn_()
        {
            return View(new WebApplication2.Models.Authentication.AuthenticationParams {});
        }

        [HttpPost]
        public ActionResult LogIn(
            [System.Web.Http.FromBody] WebApplication2.Models.Authentication.AuthenticationParams auth)
        {
            if (!ModelState.IsValid)
                return View(auth);

            if (!_authenticationService.CheckUser(auth.User, auth.Password))
                return View(new WebApplication2.Models.Authentication.AuthenticationParams
                {
                    IsAuthFailed = true,
                    Password = "",
                    User = ""
                });
            FormsAuthentication.SetAuthCookie(auth.User, true);

            return RedirectToAction("", "");
        }

        [HttpGet]
        [ActionName("Register")]
        public ActionResult Register_()
        {
            return View(new WebApplication2.Models.Authentication.AuthenticationParams {});
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register(
            [System.Web.Http.FromBody] WebApplication2.Models.Authentication.AuthenticationParams auth)
        {
            if (!ModelState.IsValid)
                return View(auth);

            if (_authenticationService.RegisterUser(auth.User, auth.Password)) 
                throw new Exception($"Ошибка при регистрации пользователя {auth.User}.");

            FormsAuthentication.SetAuthCookie(auth.User, true);
            return RedirectToAction("Phones", "Default");
        }
    }
}