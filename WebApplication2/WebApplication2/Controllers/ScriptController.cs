using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Service.Services.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Controllers
{
    public class ScriptController : Controller
    {
        private IScriptServices _scriptServices = null;

        public ScriptController(IScriptServices scriptServices)
        {
            _scriptServices = scriptServices;
        }

        public ActionResult Scripts()
        {
            var script = _scriptServices.GetScripts()
                .Select(x => new Script
                {
                    Id = x.Id,
                    Scripts = x.Scripts,
                    Description = x.Description,
                    IsDeleted = x.IsDeleted
                }).ToArray();
            return View(script);
        }
    }
}