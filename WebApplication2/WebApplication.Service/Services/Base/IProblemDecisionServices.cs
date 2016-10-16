using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services.Base
{
    public interface IProblemDecisionServices
    {
        IEnumerable<ProblemDecision> GetProblemDecisions();

        bool DeleteProblemDecision(int id);

        bool RestoreProblemDecision(int id);

        bool AddProblemDecision(ProblemDecision problemDecision);

        bool EditProblemDecision(ProblemDecision problemDecision);
    }
}