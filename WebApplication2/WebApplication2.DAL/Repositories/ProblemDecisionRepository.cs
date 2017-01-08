using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DAL.Context;
using WebApplication2.DAL.Repositories.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories
{
    public class ProblemDecisionRepository : IProblemDecisionRepository
    {
        private EasyWorkDBContext _context = null;

        //public ProblemDecisionRepository()
        //{
        //    _context = EasyWorkDBContext.Instance;
        //}

        public IEnumerable<ProblemDecision> GetProblemDecisions()
        {
            return _context.ProblemDecisions.ToArray();
        }

        public IEnumerable<ProblemDecision> GetProblemDecisions(Func<ProblemDecision, bool> func)
        {
            return _context.ProblemDecisions.Where(func).ToArray();
        }

        public ProblemDecision GetProblemDecision(int id)
        {
            return _context.ProblemDecisions.FirstOrDefault(x => x.Id == id);
        }

        public ProblemDecision GetProblemDecision(string problemDecision)
        {
            return _context.ProblemDecisions
                .FirstOrDefault(
                    x => x.Problem.ToLower()
                        .Trim() == problemDecision
                            .ToLower().Trim());
        }

        public bool DeleteProblemDecision(int id)
        {
            try
            {
                var problem = GetProblemDecision(id);
                if (problem == null)
                    return false;

                problem.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RestoreProblemDecision(int id)
        {
            try
            {
                var problem = GetProblemDecision(id);
                if (problem == null)
                    return false;

                problem.IsDeleted = true;
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool AddProblemDecision(ProblemDecision problemDecision)
        {
            try
            {
                _context.ProblemDecisions.Add(problemDecision);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditProblemDecision(ProblemDecision problemDecision)
        {
            try
            {
                var old = GetProblemDecision(problemDecision.Id);
                if (old == null)
                    return false;

                old.IsDeleted = false;
                old.Problem = problemDecision.Problem;
                old.DataAdditional = problemDecision.DataAdditional;
                old.Decision = problemDecision.Decision;
                old.PosVersion = problemDecision.PosVersion;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
