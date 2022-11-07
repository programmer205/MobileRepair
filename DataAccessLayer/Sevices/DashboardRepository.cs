using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class DashboardRepository : IDisposable
    {
        DB db = new DB();

        public DataTable GetRepairForMe(int id)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query =
                $"select RepairId,VisitDate,Customer_id,User_id,P_id,(select Model from Phones where Repairs.P_id=Phones.PhoneID )PhoneModel,(select ReceptionNumber from Phones where Repairs.P_id=Phones.PhoneID )ReceptionNumber,(select IsDone from Phones where Repairs.P_id=Phones.PhoneID)IsDone from Repairs  where Repairs.User_id={id}";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Check()
        {
            var res = db.MyInformation.Select(n => n.Status).FirstOrDefault();
            if (res == null)
            {
                return false;
            }
            else
            {
                return res;
            }
        }

        public bool InsertInfo(MyInformation information)
        {
            try
            {
                db.MyInformation.Add(information);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateInfo(MyInformation information)
        {
            try
            {
                var res = db.MyInformation.Find(information.Id);
                res.UserName = information.UserName;
                res.Password = information.Password;
                res.Status = information.Status;
                res.UserId = information.UserId;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MyInformation GetInfo()
        {
            return db.MyInformation.FirstOrDefault();
        }

        public MyInformation GetInfoByUser(string name)
        {
            return db.MyInformation.SingleOrDefault(n => n.UserName == name);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public bool update(string name,int id)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connenct_to);
            try
            {
                string query = $"update MyInformations set Password=@name where MyInformations.Id={id};";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetCountOfReminder(int id)
        {
            return db.Reminders.Where(n => n.User_Id == id && n.IsDone == false).Count();
        }

        public int GetCountOfRepair(int id)
        {
           return db.Repairs.Where(n => n.User_id == id && n.EndDate == null).Count();
        }

        public int GetCountOfCustomers()
        {
            return db.Customers.Count();
        }

        public List<Reminder> GetReminders(int id)
        {
            return db.Reminders.Where(n => n.User_Id == id && n.IsDone == false).ToList();
        }
    }
}
