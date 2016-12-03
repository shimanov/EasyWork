using System.Linq;
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

        [HttpGet]
        public ActionResult DeleteScript(int id)
        {
            _scriptServices.DeleteScript(id);
            return RedirectToAction("Scripts");
        }

        [HttpGet]
        public ActionResult RestoreScript(int id)
        {
            _scriptServices.RestoreScript(id);
            return RedirectToAction("Scripts");
        }

        [HttpGet]
        public ActionResult AddScript()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddScript(Script script)
        {
            _scriptServices.AddScript(new Script
            {
                Id = script.Id,
                Scripts = script.Scripts,
                Description = script.Description,
                IsDeleted = false
            });
            return RedirectToAction("Scripts");
        }

        [HttpGet]
        public ActionResult EditScript(int id)
        {
            var script = _scriptServices.GetScripts()
                .FirstOrDefault(x => x.Id == id);

            return View(new Script
            {
                Id = script.Id,
                Scripts = script.Scripts,
                Description = script.Description,
                IsDeleted = script.IsDeleted
            });
        }

        [HttpPost]
        public ActionResult EditScript(Script script)
        {
            _scriptServices.EditScript(new Script
            {
                Id = script.Id,
                Scripts = script.Scripts,
                Description = script.Description,
                IsDeleted = false
            });
            return RedirectToAction("Scripts");
        }

        [HttpGet]
        public ActionResult DetailsScript(int id)
        {
            var script = _scriptServices.GetScripts()
                .FirstOrDefault(x => x.Id == id);
            if (script != null)
            {
                return PartialView(script);
            }
            return HttpNotFound();

        }
    }
}