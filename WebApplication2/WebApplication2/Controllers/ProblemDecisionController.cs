using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Service.Services.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Controllers
{
    public class ProblemDecisionController : Controller
    {
        //private IProblemDecisionServices _problemDecision = null;

        //public ProblemDecisionController(IProblemDecisionServices problemDecision)
        //{
        //    _problemDecision = problemDecision;
        //}

        //public ActionResult ProblemDecision()
        //{
        //    var problem = _problemDecision.GetDecisions()
        //        .Select(x => new ProblemDecision
        //        {
        //            Id = x.Id,
        //            Problem = x.Problem,
        //            Decision = x.Decision,
        //            PosVersion = x.PosVersion,
        //            DataAdditional = x.DataAdditional
        //        }).ToArray();

        //    return View(problem);
        //}
    }
}