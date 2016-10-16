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

        #region

        IEnumerable<ProblemDecision> GetProblemDecisions();

        IEnumerable<ProblemDecision> GetProblemDecisions(Func<PhoneBook, bool> func);

        ProblemDecision GetProblemDecision(int id);

        ProblemDecision GetProblemDecision(string problem);

        bool AddProblemDecision(ProblemDecision phone);

        bool EditProblemDecision(ProblemDecision phone);

        bool DeleteProblemDecision(int id);

        bool RestoreProblemDecision(int id);

        #endregion
    }
}