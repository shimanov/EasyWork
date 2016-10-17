using System;
using System.Collections.Generic;
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

        IEnumerable<ProblemDecision> GetProblemDecisions();

        IEnumerable<ProblemDecision> GetProblemDecisions(Func<ProblemDecision, bool> func);

        ProblemDecision GetProblemDecision(int id);

        ProblemDecision GetProblemDecision(string problem);

        bool AddProblemDecision(ProblemDecision phone);

        bool EditProblemDecision(ProblemDecision phone);

        bool DeleteProblemDecision(int id);

        bool RestoreProblemDecision(int id);

        #endregion

        #region

        IEnumerable<Script> GetScripts();

        IEnumerable<Script> GetScripts(Func<Script, bool> func);

        Script GetScript(int id);

        Script GetScript(string script);

        bool AddScript(Script script);

        bool EditScript(Script script);

        bool DeleteScript(int id);

        bool RestoreScript(int id);

        #endregion
    }
}
