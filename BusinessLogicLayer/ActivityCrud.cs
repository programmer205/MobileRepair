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
    public class ActivityCrud:IDisposable
    {
        ActivityRepository db=new ActivityRepository();
        public bool Create(Activity activity)
        {
            try
            {
                db.InsertActivity(activity);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Activity activity)
        {
            try
            {
                db.UpdateActivity(activity);
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
                db.DeleteActivity(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Activity Find(int id)
        {
            return db.GetActivityById(id);
        }

        public List<string> GetAllCustomers()
        {
            return db.GetAllCustomers();
        }

        public List<string> GetAllUsers()
        {
            return db.GetAllUsers();
        }

        public int GetCustomerByPhone(string number)
        {
            CustomerRepository cs=new CustomerRepository();
            return cs.GetCustomerByPhonenumber(number);
        }

        public int GetUserName(string name)
        {
            UserRepository ur=new UserRepository();
            return ur.FindIdByUserName(name);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<ActivityViewModel> Read()
        {
            List<ActivityViewModel> activities = new List<ActivityViewModel>();
            foreach (DataRow item in db.GetAllActivitiesBySql().Rows)
            {
                activities.Add(new ActivityViewModel()
                {
                    ActivityId = int.Parse(item[0].ToString()),
                    Title = item[1].ToString(),
                    UserName = item[2].ToString(),
                    CustomerName = item[3].ToString(),
                    Info = item[4].ToString(),
                    RegDate = Convert.ToDateTime(item[5]).Shamsi()
                });
            }

            return activities;
        }

        public List<ActivityViewModel> ReadByName(string name)
        {
            List<ActivityViewModel> activities = new List<ActivityViewModel>();
            foreach (DataRow item in db.GetActivityByName(name).Rows)
            {
                activities.Add(new ActivityViewModel()
                {
                    ActivityId = int.Parse(item[0].ToString()),
                    Title = item[1].ToString(),
                    UserName = item[2].ToString(),
                    CustomerName = item[3].ToString(),
                    Info = item[4].ToString(),
                    RegDate = Convert.ToDateTime(item[5]).Shamsi()
                });
            }

            return activities;
        }
    }
}
