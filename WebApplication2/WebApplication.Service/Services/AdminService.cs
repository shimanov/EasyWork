using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DAL.Repositories.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services
{
    public class AdminService : Base.IAdminService
    {
        IEasyWorkRepository _easyWorkRepository = null;

        public AdminService(IEasyWorkRepository easyWorkRepository)
        {
            _easyWorkRepository = easyWorkRepository;
        }

        public bool UserInGroup(string userName, string groupName)
        {
            var user = _easyWorkRepository.GetUser(userName);

            if (user == null)
                return false;

            return user.Group.Name.Trim().ToLower() == groupName;
        }

        public IEnumerable<User> GetUsers()
        {
            return _easyWorkRepository.GetUsers();
        }

        public IEnumerable<Group> GetGroups()
        {
            return _easyWorkRepository.GetGroups();
        }

        public bool DeleteUser(int id)
        {
            return _easyWorkRepository.DeleteUser(id);
        }

        public bool RestoreUser(int id)
        {
            return _easyWorkRepository.RestoreUser(id);
        }

        public bool AddUser(User user)
        {
            var bytes = Encoding.UTF8.GetBytes(user.Password);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);

            user.Password = passwordBase64;

            return _easyWorkRepository.AddUser(user);
        }

        public bool EditUser(User user)
        {
            var bytes = Encoding.UTF8.GetBytes(user.Password);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);

            user.Password = passwordBase64;

            return _easyWorkRepository.EditUser(user);
        }


    }
}
