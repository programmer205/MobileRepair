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
    public class PhoneRepository : IPhoneRepository
    {
        DB db=new DB();
        public bool DeletePhone(Phone phone)
        {
            try
            {
                db.Entry(phone).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePhone(int phoneId)
        {
            try
            {
                var res = GetPhoneById(phoneId);
                DeletePhone(res);
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

        public DataTable GetAllPhoneBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select PhoneID,Model,BarCode,RegDate,EndDate,IsDone,Description,Visit,ReceptionNumber,ProposedPrice,(select FullName from Customers where Customers.CustomerId=Phones.CustomerId)CustomerName ,(select PhoneNumber from Customers where Customers.CustomerId=Phones.CustomerId)PhoneNumber,FinalPrice from Phones";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            return db.Phones;
        }

        public Phone GetPhoneById(int phoneId)
        {
            return db.Phones.Find(phoneId);
        }

        public DataTable GetPhoneByName(string name)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select PhoneID,Model,BarCode,RegDate,EndDate,IsDone,Description,Visit,ReceptionNumber,ProposedPrice,(select FullName from Customers where Customers.CustomerId=Phones.CustomerId)CustomerName ,(select PhoneNumber from Customers where Customers.CustomerId=Phones.CustomerId)PhoneNumber,FinalPrice from Phones left join Customers on Phones.CustomerId=Customers.CustomerId where Phones.BarCode like '%{name}%' or Customers.PhoneNumber like '%{name}%' or Customers.FullName like '%{name}%' or Phones.ReceptionNumber like '%{name}%' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool InsertPhone(Phone phone)
        {
            try
            {
                Random random = new Random();
                string s = random.Next(1000).ToString();
                var res = db.Phones.Where(n => n.ReceptionNumber == s);
                while (res.Count() > 0)
                {
                    s = random.Next(1000000).ToString();
                }

                phone.ReceptionNumber = s;
                db.Phones.Add(phone);
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

        public bool UpdatePhone(Phone phone)
        {
            try
            {
                db.Entry(phone).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Phone> GetPhones(int id)
        {
            return db.Phones.Where(n => n.CustomerId == id && n.IsDone == true && n.IsPay == false).ToList();
        }
    }
}
