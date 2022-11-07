using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Utility;
using ViewModels;

namespace BusinessLogicLayer
{
    public class InvoiceCrud:IDisposable
    {
        InvoiceRepository db=new InvoiceRepository();
        public bool Create(Invoice invoice, List<Phone> phones)
        {
            try
            {
                db.InsertInvoice(invoice, phones);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Invoice invoice)
        {
            try
            {
                db.UpdateInvoice(invoice);
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
                db.DeleteInvoice(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> GetAllCustomers()
        {
            return db.GetAllCustomers();
        }

        public Customer GetCustomerByPhone(string number)
        {
            CustomerRepository cs=new CustomerRepository();
            return cs.GetCustomerByPhone(number);
        }

        public List<Phone> GetPhones(int id)
        {
            return db.GetPhones(id);
        }

        public List<Phone> MyPhone(int id)
        {
            return db.MyPhones(id);
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public string ReturnInvoiceNumber()
        {
            return db.ReturnInvoiceNumber();
        }

        public Customer GetCustomerById(int id)
        {
            CustomerRepository cs=new CustomerRepository();
            return cs.GetCustomerById(id);
        }

        public DataTable Report(int id)
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Price");
            foreach (var item in MyPhone(id))
            {
                dt.Rows.Add(item.Model, item.FinalPrice);
            }

            return dt;
        }

        public List<InvoiceViewModel> Read()
        {
            List<InvoiceViewModel> invoices=new List<InvoiceViewModel>();
            foreach (DataRow item in db.GetAllInvoicesBySql().Rows)
            {
                invoices.Add(new InvoiceViewModel()
                {
                    InvoiceId = int.Parse(item[0].ToString()),
                    InvoiceNumber = item[1].ToString(),
                    RegDate = Convert.ToDateTime(item[2]).Shamsi(),
                    FinalPrice = item[3].ToString(),
                    UserName = item[4].ToString(),
                    CustomerName = item[5].ToString(),
                    PhoneNumber = item[6].ToString()
                });
            }

            return invoices;
        }

        public List<InvoiceViewModel> ReadByName(string name)
        {
            List<InvoiceViewModel> invoices = new List<InvoiceViewModel>();
            foreach (DataRow item in db.GetInvoiceByName(name).Rows)
            {
                invoices.Add(new InvoiceViewModel()
                {
                    InvoiceId = int.Parse(item[0].ToString()),
                    InvoiceNumber = item[1].ToString(),
                    RegDate = Convert.ToDateTime(item[2]).Shamsi(),
                    FinalPrice = item[3].ToString(),
                    UserName = item[4].ToString(),
                    CustomerName = item[5].ToString(),
                    PhoneNumber = item[6].ToString()
                });
            }

            return invoices;
        }

        public DataTable GetReports(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Price");
            foreach (DataRow item in db.GetReports(id).Rows)
            {
                dt.Rows.Add(item[1].ToString(), item[10].ToString());
            }

            return dt;
        }

        public DataTable PhonesUs(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Model");
            dt.Columns.Add("Price");
            foreach (var item in db.PhonesUs(id))
            {
                dt.Rows.Add(item.Model,item.FinalPrice);
            }

            return dt;
        }
    }
}
