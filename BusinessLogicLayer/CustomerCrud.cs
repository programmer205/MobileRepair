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
    public class CustomerCrud:IDisposable
    {
        CustomerRepository db=new CustomerRepository();
        public bool Create(Customer customer)
        {
            try
            {
                if (GetCustomerByPhone(customer.PhoneNumber) == null)
                {
                    db.InsertCustomer(customer);
                    db.Save();
                    db.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch
            {
                return false;
            }
        }

        public List<CustomerViewModel> GetAllCustomers()
        {
            List<CustomerViewModel> Customers=new List<CustomerViewModel>();
            foreach (DataRow item in db.GetAllCustomersBySql().Rows)
            {
                Customers.Add(new CustomerViewModel()
                {
                    CustomerId = int.Parse(item[0].ToString()),
                    FullName = item[1].ToString(),
                    PhoneNumber = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi()
                });
            }

            return Customers;
        }

        public List<CustomerViewModel> GetCustomerByName(string name)
        {
            List<CustomerViewModel> Customers = new List<CustomerViewModel>();
            foreach (DataRow item in db.GetCustomerByName(name).Rows)
            {
                Customers.Add(new CustomerViewModel()
                {
                    CustomerId = int.Parse(item[0].ToString()),
                    FullName = item[1].ToString(),
                    PhoneNumber = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi()
                });
            }

            return Customers;
        }

        public bool Edit(Customer cs)
        {
            try
            {

                db.UpdateCustomer(cs);
                db.Save();
                db.Dispose();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var find = db.DeleteCustomer(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Customer Find(int id)
        {
            return db.GetCustomerById(id);
        }

        public List<string> SelectAllName()
        {
            return db.SelectAllName();
        }

        public Customer GetCustomerByPhone(string number)
        {
            return db.GetCustomerByPhone(number);
        }

        public List<Customer> GetCustomerByText(string name)
        {
            return db.GetCustomerByText(name);
        }

        public List<Customer> SelectAll()
        {
            return db.GetAllCustomers().ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
