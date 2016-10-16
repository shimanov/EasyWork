﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.DAL.Context;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories
{
    public class EasyWorkRepository : Base.IEasyWorkRepository
    {
        private EasyWorkDBContext _context = null;

        public EasyWorkRepository()
        {
            _context = EasyWorkDBContext.Instance;
        }


        #region PhoneBook
        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            return _context.PhoneBooks.ToArray();
        }

        public IEnumerable<PhoneBook> GetPhoneBooks(Func<PhoneBook, bool> func)
        {
            return _context.PhoneBooks.Where(func).ToArray();
        }

        public PhoneBook GetPhoneBook(int id)
        {
            return _context.PhoneBooks.FirstOrDefault(x => x.Id == id);
        }

        public PhoneBook GetPhoneBook(string phonenumber)
        {
            return _context.PhoneBooks
                .FirstOrDefault
                (x => x.PhoneNumber
                .Trim().ToLower() == phonenumber
                .Trim().ToLower());
        }

        public bool AddPhone(PhoneBook phone)
        {
            try
            {
                _context.PhoneBooks.Add(phone);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditPhone(PhoneBook phone)
        {
            try
            {
                var old = GetPhoneBook(phone.Id);
                if (old == null)
                    return false;

                old.Fio = phone.Fio;
                old.PhoneNumber = phone.PhoneNumber;
                old.Pochtamt = phone.Pochtamt;
                old.IsDeleted = false;

                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePhone(int id)
        {
            try
            {
                var phone = GetPhoneBook(id);

                if (phone == null)
                    return false;
                phone.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RestorePhone(int id)
        {
            try
            {
                var phone = GetPhoneBook(id);

                if (phone == null)
                    return false;
                phone.IsDeleted = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region ProblemDecision

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

        public ProblemDecision GetProblemDecision(string problem)
        {
            return _context.ProblemDecisions
                .FirstOrDefault(x =>
                    x.Problem.Trim().ToLower() == problem.ToLower().Trim());
        }

        public bool AddProblemDecision(ProblemDecision problem)
        {
            try
            {
                _context.ProblemDecisions.Add(problem);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
            
        }

        public bool EditProblemDecision(ProblemDecision problem)
        {

            try
            {
                var old = GetProblemDecision(problem.Id);
                if (old == null)
                    return false;

                old.IsDeleted = false;
                old.DataAdditional = DateTime.Now;
                old.Problem = problem.Problem;
                old.Decision = problem.Decision;
                old.PosVersion = problem.PosVersion;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
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
                problem.IsDeleted = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
