using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories.Base
{
    public interface IEasyWorkRepository
    {
        #region PhoneBook

        IEnumerable<PhoneBook> GetPhoneBooks();

        IEnumerable<PhoneBook> GetPhoneBooks(Func<PhoneBook, bool> func);

        PhoneBook GetPhoneBook (int id);

        PhoneBook GetPhoneBook (string phoneNumber);

        bool AddPhone(PhoneBook phone);

        bool EditPhone(PhoneBook phone);

        bool DeletePhone(int id);

        bool RestorePhone(int id);

        #endregion

        #region ProblemDecision

        /*IEnumerable<ProblemDecision> GetDecisions();

        IEnumerable<ProblemDecision> GetDecisions(Func<ProblemDecision, bool> func);

        ProblemDecision GetDecision(int id);

        ProblemDecision GetDecision(string problem);

        bool AddProblem(ProblemDecision problem);

        bool EditProblem(ProblemDecision problem);

        bool DeleteProblem(int id);

        bool RestoreProblem(int id);*/

        #endregion
    }
}
