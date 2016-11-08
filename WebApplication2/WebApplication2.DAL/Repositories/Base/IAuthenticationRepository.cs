using WebApplication2.Domain.Entities;

namespace WebApplication2.DAL.Repositories.Base
{
    public interface IAuthenticationRepository
    {
        User GetUser(string userName);

        bool RegisterUser(User user);

        bool RegisterUser(string userName, string userPassword, int groupId);

        bool RemoveUser(User userToRemove);

        bool RemoveUser(int id);
    }
}