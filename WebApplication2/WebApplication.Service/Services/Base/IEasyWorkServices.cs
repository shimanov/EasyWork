using System;
using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services.Base
{
    public interface IEasyWorkServices
    {
        #region PhoneBook
        IEnumerable<PhoneBook> GetPhoneBooks();

        IEnumerable<PhoneBook> GetPhoneBooks(Func<PhoneBook, bool> func);

        PhoneBook GetPhoneBook(int id);

        PhoneBook GetPhoneBook(string fio);

        bool AddPhone(PhoneBook phone);

        bool EditPhone(PhoneBook phone);

        bool DeletePhone(int id);

        bool RestorePhone(int id);
        #endregion

        #region ProblemDecision

        IEnumerable<ProblemDecision> GetProblemDecisions();

        IEnumerable<ProblemDecision> GetProblemDecisions(Func<ProblemDecision, bool> func);

        ProblemDecision GetDecision(int id);

        ProblemDecision GetDecision(string problem);

        bool AddProblem(ProblemDecision problem);

        bool EditProblem(ProblemDecision problem);

        bool DeleteProblem(int id);

        bool RestoreProblem(int id);

        #endregion
    }
}