using System;
using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories.Base
{
    public interface IProblemDecisionRepository
    {
        IEnumerable<ProblemDecision> GetProblemDecisions();

        IEnumerable<ProblemDecision> GetProblemDecisions(Func<ProblemDecision, bool> func);

        ProblemDecision GetProblemDecision(int id);

        ProblemDecision GetProblemDecision(string problemDecision);

        bool DeleteProblemDecision(int id);

        bool RestoreProblemDecision(int id);

        bool AddProblemDecision(ProblemDecision problemDecision);

        bool EditProblemDecision(ProblemDecision problemDecision);
    }
}