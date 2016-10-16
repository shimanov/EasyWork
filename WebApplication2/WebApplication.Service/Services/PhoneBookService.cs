using System.Collections.Generic;
using WebApplication2.DAL.Repositories.Base;
using WebApplication2.Domain.Entities;

namespace WebApplication.Service.Services
{
    public class PhoneBookService :Base.IPhoneBookService
    {
        IEasyWorkRepository _easyWorkRepositiry = null;
        

        public PhoneBookService(IEasyWorkRepository easyWorkRepositiry)
        {
            _easyWorkRepositiry = easyWorkRepositiry;
        }

        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            return _easyWorkRepositiry.GetPhoneBooks();
        }

        public bool AddPhone(PhoneBook phone)
        {
            return _easyWorkRepositiry.AddPhone(phone);
        }

        public bool DeletePhone(int id)
        {
            return _easyWorkRepositiry.DeletePhone(id);
        }

        public bool EditPhone(PhoneBook phone)
        {
            return _easyWorkRepositiry.EditPhone(phone);
        }

        public bool RestorePhone(int id)
        {
            return _easyWorkRepositiry.RestorePhone(id);
        }
    }
}
