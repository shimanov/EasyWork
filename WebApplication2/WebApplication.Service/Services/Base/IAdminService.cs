using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services.Base
{
    public interface IAdminService
    {
        bool UserInGroup(string userName, string groupName);

        IEnumerable<User> GetUsers();

        IEnumerable<Group> GetGroups();

        bool DeleteUser(int id);

        bool RestoreUser(int id);

        bool AddUser(User user);

        bool EditUser(User user);
    }
}