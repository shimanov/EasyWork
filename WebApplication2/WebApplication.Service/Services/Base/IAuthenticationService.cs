namespace WebApplication.Service.Services.Base
{
    public interface IAuthenticationService
    {
        bool RegisterUser(string userName, string userPassword);
        bool CheckUser(string userName, string userPassword);
    }
}