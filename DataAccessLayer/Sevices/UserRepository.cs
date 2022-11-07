using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        DB db=new DB();
        public bool DeleteUser(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var res = GetUserById(userId);
                DeleteUser(res);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users;
        }

        public DataTable GetAllUsersBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select UserId,Name,UserName,Password,Picture,Status,RegDate,Tiltle from Users left join UserGroups on Users.GroupId=UserGroups.Id";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable GetUsersWithoutAdmin()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select UserId,Name,UserName,Password,Picture,Status,RegDate,Tiltle from Users left join UserGroups on Users.GroupId=UserGroups.Id where UserGroups.Tiltle !='مدیریت'";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public User GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public DataTable GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(User user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            try
            { 
                db.Entry(user).State=EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<string> GetAllNames()
        {
            return db.Users.Select(n => n.UserName).ToList();
        }

        public int FindIdByUserName(string name)
        {
            var res= db.Users.SingleOrDefault(n => n.UserName == name);
            if (res == null)
            {
                return 0;
            }
            else
            {
                return res.UserId;
            }
        }

        public List<User> SelectALl()
        {
            return db.Users.ToList();
        }

        public User GetUserByUserName(string name)
        {
            return db.Users.Include("UserGroup").SingleOrDefault(n => n.UserName == name);
        }

        public bool Access(User user, string section, int allow)
        {
            UserGroup userGroup = db.UserGroups.SingleOrDefault(n => n.Id == user.GroupId);
            var Role = db.AccessRoles.Where(n => n.GroupId == userGroup.Id).ToList();
            AccessRole accessRole = Role.SingleOrDefault(n => n.Section == section);
            if (allow == 1)
            {
                return accessRole.CanEnter;
            }
            if (allow == 2)
            {
                return accessRole.CanCreate;
            }
            if (allow == 3)
            {
                return accessRole.CanUpdate;
            }
            else
            {
                return accessRole.CanDelete;
            }

        }

        public User SearchPhone(string number)
        {
            var res = db.Users.SingleOrDefault(n => n.PhoneNumber == number);
            if (res==null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public User GetUserByPhone(string number)
        {
            return db.Users.SingleOrDefault(n => n.PhoneNumber == number);
        }
    }
}
