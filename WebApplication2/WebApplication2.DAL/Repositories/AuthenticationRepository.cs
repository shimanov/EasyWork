using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DAL.Context;
using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories
{
    public class AuthenticationRepository : Base.IAuthenticationRepository
    {
        EasyWorkDBContext _context = null;

        public AuthenticationRepository()
        {
            _context = EasyWorkDBContext.Instance;
        }

        public User GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(x => x.Email == userName);
        }

        public bool RegisterUser(User user)
        {
            bool isSaved = false;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception exception)
            {
               
                isSaved = false;
            }

            return isSaved;
        }

        public bool RegisterUser(string userName, string userPassword, int groupId)
        {
            bool isSaved = false;

            try
            {
                _context.Users.Add(new User
                {
                    Email = userName,
                    Password = userPassword,
                    GroupId = groupId,
                    IsDeleted = false
                });
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception)
            {
                isSaved = false;
            }
            return isSaved;
        }

        public bool RemoveUser(User userToRemove)
        {
            bool isRemoved = false;

            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == userToRemove.Id);

                if (user == null)
                    return false;

                user.IsDeleted = true;

                _context.SaveChanges();
                isRemoved = true;
            }
            catch (Exception)
            {
                isRemoved = false;
            }

            return isRemoved;
        }

        public bool RemoveUser(int id)
        {
            bool isRemoved = false;

            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);

                if (user == null)
                    return false;

                user.IsDeleted = false;

                _context.SaveChanges();
                isRemoved = true;
            }
            catch (Exception)
            {
                isRemoved = false;
            }

            return isRemoved;
        }
    }
}
