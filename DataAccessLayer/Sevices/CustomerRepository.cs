using Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        DB db=new DB();
        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            try
            {
                var res = GetCustomerById(customerId);
                DeleteCustomer(res);
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

        public IEnumerable<Customer> GetAllCustomers()
        {
            return db.Customers;
        }

        public DataTable GetAllCustomersBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select * from Customers";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public Customer GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public DataTable GetCustomerByName(string name)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select * from Customers where FullName like '%{name}%' or PhoneNumber like '%{name}%'";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
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

        public List<string> SelectAllName()
        {
            return db.Customers.Select(n => n.PhoneNumber).ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                db.Entry(customer).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetCustomerByPhone(string number)
        {
            return db.Customers.SingleOrDefault(n => n.PhoneNumber == number);
        }

        public int GetCustomerByPhonenumber(string number)
        {
            var res= db.Customers.SingleOrDefault(n => n.PhoneNumber == number);
            if (res == null)
            {
                return 0;
            }
            else
            {
                return res.CustomerId;
            }
        }

        public List<Customer> GetCustomerByText(string name)
        {
            return db.Customers.Where(n => n.FullName.Contains(name) || n.PhoneNumber.Contains(name)).ToList();
        }
    }
}
