using System.Collections.Generic;
using WebApplication2.DAL.Repositories.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services
{
    public class ProblemDecisionServices : Base.IProblemDecisionServices
    {
        private IEasyWorkRepository _easyWorkRepository = null;

        public ProblemDecisionServices(IEasyWorkRepository easyWorkRepository)
        {
            _easyWorkRepository = easyWorkRepository;
        }


        public IEnumerable<ProblemDecision> GetProblemDecisions() =>
            _easyWorkRepository.GetProblemDecisions();


        public bool DeleteProblemDecision(int id) =>
            _easyWorkRepository.DeleteProblemDecision(id);


        public bool RestoreProblemDecision(int id) =>
            _easyWorkRepository.RestoreProblemDecision(id);


        public bool AddProblemDecision(ProblemDecision problemDecision) =>
            _easyWorkRepository.AddProblemDecision(problemDecision);


        public bool EditProblemDecision(ProblemDecision problemDecision) =>
            _easyWorkRepository.EditProblemDecision(problemDecision);

    }
}
