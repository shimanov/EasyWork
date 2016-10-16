using System.Collections.Generic;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services.Base
{
    public interface IPhoneBookService
    {
        IEnumerable<PhoneBook> GetPhoneBooks();

        bool DeletePhone(int id);

        bool RestorePhone(int id);

        bool AddPhone(PhoneBook phone);

        bool EditPhone(PhoneBook phone);
    }
}