using System;
using System.Text;
using WebApplication2.DAL.Repositories.Base;

namespace WebApplication.Service.Services
{
    public class AuthenticationService :Base.IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepository = null;
        IEasyWorkRepository _easyWorkRepository = null;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IEasyWorkRepository easyWorkRepository)
        {
            _authenticationRepository = authenticationRepository;
            _easyWorkRepository = easyWorkRepository;
        }

        public bool CheckUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _easyWorkRepository.GetUser(userName);

            if (user == null)
                return false;

            return user.Password == passwordBase64;
        }

        public bool RegisterUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _easyWorkRepository.GetUser(userName);

            if (user != null)
                return false;

            return _authenticationRepository.RegisterUser(new WebApplication2.Domain.Entities.User
            {
                GroupId = 2,
                IsDeleted = false,
                Email = userName,
                Password = passwordBase64
            });
        }

    }
}