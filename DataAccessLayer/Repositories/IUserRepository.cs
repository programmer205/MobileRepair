using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IUserRepository:IDisposable
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int userId);

        DataTable GetUserByName(string name);

        DataTable GetAllUsersBySql();

        bool InsertUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        bool DeleteUser(int userId);

        void Save();
    }
}
