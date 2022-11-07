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
    public class RepairsRepository : IRepairsRepository
    {
        DB db = new DB();
        public bool DeleteRepair(Repair repair)
        {
            try
            {
                db.Entry(repair).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRepair(int id)
        {
            try
            {
                var res=GetRepairById(id);
                DeleteRepair(res);
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

        public IEnumerable<Repair> GetAllRepairs()
        {
            return db.Repairs;
        }

        public DataTable GetAllRepairsBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select ReceptionNumber,Model,BarCode,Phones.RegDate,Description,(select FullName from Customers where Customers.CustomerId=Phones.CustomerId)CustomerName,(select PhoneNumber from Customers where Customers.CustomerId=Phones.CustomerId)PhoneNumber,PhoneID from Phones left join Customers on Phones.CustomerId=Customers.CustomerId where Phones.Visit=0";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public Repair GetRepairById(int id)
        {
            return db.Repairs.Find(id);
        }

        public DataTable GetRepairByName()
        {
            throw new NotImplementedException();
        }

        public bool InsertRepair(Repair repair)
        {
            try
            {
                db.Repairs.Add(repair);
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

        public bool UpdateRepair(Repair repair)
        {
            try
            {
                db.Entry(repair).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
