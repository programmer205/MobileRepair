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
    public class ActivityRepository : IActivityRepository
    {
        DB db=new DB();
        public bool DeleteActivity(Activity activity)
        {
            try
            {
                db.Entry(activity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteActivity(int activityId)
        {
            try
            {
                var res = GetActivityById(activityId);
                DeleteActivity(res);
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

        public Activity GetActivityById(int activityId)
        {
            return db.Activities.Find(activityId);
        }

        public DataTable GetActivityByName(string name)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select ActivityId,Title,(select FullName from Customers where Customers.CustomerId=Activities.Customer_Id)CustomerName,(select UserName from Users where Users.UserId=Activities.User_id)UserName,Info,Activities.RegDate from Activities inner join Users on Users.UserId=Activities.User_id inner join Customers on Customers.CustomerId=Activities.Customer_Id where Customers.FullName like '%{name}%' or Users.UserName like '%{name}%' or Activities.Title like '%{name}%';";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return db.Activities;
        }

        public DataTable GetAllActivitiesBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select ActivityId,Title,(select Name from Users where Users.UserId=Activities.User_id)UserName,(select FullName from Customers where Customers.CustomerId=Activities.Customer_Id)CustomerName,Info,RegDate from Activities";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool InsertActivity(Activity activity)
        {
            try
            {
                db.Activities.Add(activity);
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

        public bool UpdateActivity(Activity activity)
        {
            try
            {
                db.Entry(activity).State=EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> GetAllCustomers()
        {
            return db.Customers.Select(n => n.PhoneNumber).ToList();
        }

        public List<string> GetAllUsers()
        {
            return db.Users.Select(n => n.UserName).ToList();
        }
    }
}
