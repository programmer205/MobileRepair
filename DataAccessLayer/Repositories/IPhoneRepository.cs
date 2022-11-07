using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IPhoneRepository:IDisposable
    {
        IEnumerable<Phone> GetAllPhones();

        Phone GetPhoneById(int phoneId);

        bool InsertPhone(Phone phone);

        bool UpdatePhone(Phone phone);

        bool DeletePhone(Phone phone);

        bool DeletePhone(int phoneId);

        DataTable GetAllPhoneBySql();

        DataTable GetPhoneByName(string name);

        void Save();
    }
}
