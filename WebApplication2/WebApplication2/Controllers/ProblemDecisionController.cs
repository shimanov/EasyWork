using System.Linq;
using System.Web.Mvc;
using Stormpath.AspNet.WebApi;
using WebApplication.Service.Services.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Controllers
{
    [Authorize]
    [StormpathGroupsRequired("admin")]
    [StormpathGroupsRequired("user")]
    public class ProblemDecisionController : Controller
    {
        private IProblemDecisionServices _problemDecision = null;

        public ProblemDecisionController(IProblemDecisionServices problemDecisionServices)
        {
            _problemDecision = problemDecisionServices;
        }

        public ActionResult ProblemDecision()
        {
            var problem = _problemDecision.GetProblemDecisions()
                .Select(x => new ProblemDecision
                {
                    Id = x.Id,
                    Problem = x.Problem,
                    Decision = x.Decision,
                    DataAdditional = x.DataAdditional,
                    IsDeleted = x.IsDeleted,
                    PosVersion = x.PosVersion
                }).ToArray();
            return View(problem);
        }

        [HttpGet]
        public ActionResult DeleteProblemDecision(int id)
        {
            _problemDecision.DeleteProblemDecision(id);
            return RedirectToAction("ProblemDecision");
        }

        [HttpGet]
        public ActionResult RestoreProblemDecision(int id)
        {
            _problemDecision.RestoreProblemDecision(id);
            return RedirectToAction("ProblemDecision");
        }

        [HttpGet]
        public ActionResult AddProblemDecision()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProblemDecision(ProblemDecision problem)
        {
            _problemDecision.AddProblemDecision(new ProblemDecision
            {
                DataAdditional = problem.DataAdditional,
                Decision = problem.Decision,
                Id = problem.Id,
                IsDeleted = false,
                PosVersion = problem.PosVersion,
                Problem = problem.Problem
            });
            return RedirectToAction("ProblemDecision");
        }

        [HttpGet]
        public ActionResult EditProblemDecision(int id)
        {
            var problem = _problemDecision.GetProblemDecisions()
                .FirstOrDefault(x => x.Id == id);

            return View(new ProblemDecision
            {
                DataAdditional = problem.DataAdditional,
                Decision = problem.Decision,
                Id = problem.Id,
                IsDeleted = problem.IsDeleted,
                PosVersion = problem.PosVersion,
                Problem = problem.Problem
            });
        }

        [HttpPost]
        public ActionResult EditProblemDecision(ProblemDecision problem)
        {
            _problemDecision.EditProblemDecision(new ProblemDecision
            {
                DataAdditional = problem.DataAdditional,
                Decision = problem.Decision,
                Id = problem.Id,
                IsDeleted = false,
                PosVersion = problem.PosVersion,
                Problem = problem.Problem
            });
            return RedirectToAction("ProblemDecision");
        }
    }
}