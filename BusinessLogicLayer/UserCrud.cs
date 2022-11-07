using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Utility;
using ViewModels;

namespace BusinessLogicLayer
{
    public class UserCrud:IDisposable
    {
        UserRepository db = new UserRepository();
        private string Encode(string pass)
        {
            byte[] end_Data_byte = new byte[pass.Length];
            end_Data_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string EnCodeData = Convert.ToBase64String(end_Data_byte);
            return EnCodeData;
        }

        private string Dicode(string encoded)
        {
            System.Text.UTF8Encoding Encoder = new UTF8Encoding();
            System.Text.Decoder decoder = Encoder.GetDecoder();
            byte[] todecodeBytes = Convert.FromBase64String(encoded);
            int charcount = decoder.GetCharCount(todecodeBytes, 0, todecodeBytes.Length);
            char[] decoded_char = new char[charcount];
            decoder.GetChars(todecodeBytes, 0, todecodeBytes.Length, decoded_char, 0);
            string Result = new string(decoded_char);
            return Result;
        }

        public bool Create(User user)
        {
            try
            {
                if (GetUserByPhone(user.PhoneNumber) == null)
                {
                    user.Password = Encode(user.Password);
                    db.InsertUser(user);
                    db.Save();
                    db.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User Find(int id)
        {
            return db.GetUserById(id);
        }

        public bool Edit(User user)
        {
            try
            {
                user.Password = Encode(user.Password);
                db.UpdateUser(user);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.DeleteUser(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User GetUserByPhone(string number)
        {
            return db.GetUserByPhone(number);
        }

        public List<UserViewModel> Read()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (DataRow item in db.GetAllUsersBySql().Rows)
            {
                users.Add(new UserViewModel()
                {
                    UserId = int.Parse(item[0].ToString()),
                    Name = item[1].ToString(),
                    UserName = item[2].ToString(),
                    Password = item[3].ToString(),
                    Picture = item[4].ToString(),
                    Status = Convert.ToBoolean(item[5]),
                    RegDate = Convert.ToDateTime(item[6]).Shamsi(),
                    Title = item[7].ToString()
                });
            }

            return users;
        }

        public List<UserViewModel> ReadWithoutAdmin()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (DataRow item in db.GetUsersWithoutAdmin().Rows)
            {
                users.Add(new UserViewModel()
                {
                    UserId = int.Parse(item[0].ToString()),
                    Name = item[1].ToString(),
                    UserName = item[2].ToString(),
                    Password = item[3].ToString(),
                    Picture = item[4].ToString(),
                    Status = Convert.ToBoolean(item[5]),
                    RegDate = Convert.ToDateTime(item[6]).Shamsi(),
                    Title = item[7].ToString()
                });
            }

            return users;
        }
        public bool Login(string user, string pass)
        {
            string password = Encode(pass);
            UserRepository db = new UserRepository();
            var res = db.SelectALl();
            var username = res.Where(n => n.UserName == user).Any();
            var status = res.Where(n => n.Password == password).Any();
            if (username && status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUserByUserName(string name)
        {
            return db.GetUserByUserName(name);
        }

        public List<User> ReadAll()
        {
            return db.GetAllUsers().ToList();
        }

        public bool Access(User user, string section, int allow)
        {
            return db.Access(user, section, allow);
        }

        public User SearchPhone(string number)
        {
            return db.SearchPhone(number);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
