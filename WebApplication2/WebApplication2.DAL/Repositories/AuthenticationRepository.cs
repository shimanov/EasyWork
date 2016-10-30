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


        public bool RegisterUser(User user)
        {
            bool isSaved = false;

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
            }

            return isSaved;
        }

        public bool RegisterUser(string userName, string userPassword, int groupId)
        {
            bool isSaver = false;

            try
            {
                _context.Users.Add(new User
                {
                    Name = userName,
                    Password = userPassword,
                    GroupId = groupId,
                    IsDeleted = false
                });
                isSaver = true;
            }
            catch (Exception)
            {
                isSaver = false;
            }

            return isSaver;
        }

        public bool RemoveUser(User userToRemove)
        {
            bool isRemoved = false;

            try
            {
                var user = _context.Users.FirstOrDefault(
                    x => x.Id == userToRemove.Id);

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
                var user = _context.Users.FirstOrDefault(
                    x => x.Id == id);

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
    }
}
