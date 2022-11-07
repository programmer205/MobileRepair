using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
   public interface ICustomerRepository:IDisposable
    {
        IEnumerable<Customer> GetAllCustomers();

        Customer GetCustomerById(int customerId);

        bool InsertCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Customer customer);

        bool DeleteCustomer(int customerId);

        DataTable GetAllCustomersBySql();

        DataTable GetCustomerByName(string name);

        List<string> SelectAllName();

        void Save();
    }
}
