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
    public class ReminderRepository : IReminderRepository
    {
        DB db=new DB();
        public bool DeleteReminder(Reminder reminder)
        {
            try
            {
                db.Entry(reminder).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteReminder(int reminderId)
        {
            try
            {
                var res = GetReminderById(reminderId);
                DeleteReminder(res);
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

        public IEnumerable<Reminder> GetAllReminders()
        {
            return db.Reminders;
        }

        public DataTable GetAllRemindersBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select ReminderId,ReminderTitle,UserName,ReminderInfo,IsDone,Reminders.RegDate,RemindDate,User_Id from Reminders left join Users on Reminders.User_Id=Users.UserId";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public Reminder GetReminderById(int reminderId)
        {
            return db.Reminders.Find(reminderId);
        }

        public DataTable GetReminderByName(string name)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select ReminderId,ReminderTitle,UserName,ReminderInfo,IsDone,Reminders.RegDate,RemindDate,User_Id from Reminders left join Users on Reminders.User_Id=Users.UserId where Reminders.ReminderTitle like '%{name}%' or Users.UserName like '%{name}%'";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool InsertReminder(Reminder reminder)
        {
            try
            {
                db.Reminders.Add(reminder);
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

        public bool UpdateReminder(Reminder reminder)
        {
            try
            {
                db.Entry(reminder).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetName(int userId)
        {
            var q = db.Reminders.Single(n => n.ReminderId == userId).User_Id;
            var res = db.Users.Single(n => n.UserId == q).UserName;
            return res;
        }
    }
}
