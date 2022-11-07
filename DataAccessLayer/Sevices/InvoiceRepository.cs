using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class InvoiceRepository : IInvoiceRepository
    {
        DB db=new DB();
        public bool DeleteInvoice(Invoice invoice)
        {
            try
            {
                db.Entry(invoice).State = EntityState.Deleted;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteInvoice(int invoiceId)
        {
            try
            {
                var res = GetInvoiceById(invoiceId);
                DeleteInvoice(res);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return db.Invoices;
        }

        public DataTable GetAllInvoicesBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select InvoiceId,InvoiceNumber,RegDate,FinalPrice,(select UserName from Users where Users.UserId=Invoices.UserId)UserName,(select FullName from Customers where Customers.CustomerId=Invoices.Customer_id)CustomerName,(select PhoneNumber from Customers where Customers.CustomerId=Invoices.Customer_id)PhoneNumber from Invoices";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return db.Invoices.Find(invoiceId);
        }

        public DataTable GetInvoiceByName(string name)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select InvoiceId,InvoiceNumber,Invoices.RegDate,FinalPrice,(select UserName from Users where Users.UserId=Invoices.UserId)UserName,(select FullName from Customers where Customers.CustomerId=Invoices.Customer_id)CustomerName from Invoices left join Customers on Invoices.Customer_id=Customers.CustomerId where InvoiceNumber like '%{name}%' or Customers.PhoneNumber like '%{name}%' or Customers.FullName like '%{name}%' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool InsertInvoice(Invoice invoice, List<Phone> phones)
        {
            try
            {
                foreach (var item in phones)
                {
                    invoice.Phones.Add(db.Phones.Find(item.PhoneID));
                }
                Random random = new Random();
                string s = random.Next(1000000).ToString();
                var res = db.Invoices.Where(n => n.InvoiceNumber == s);
                while (res.Count() > 0)
                {
                    s = random.Next(1000000).ToString();
                }

                invoice.InvoiceNumber = s;
                db.Invoices.Add(invoice);
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

        public bool UpdateInvoice(Invoice invoice)
        {
            try
            {
                db.Entry(invoice).State = EntityState.Modified;
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

        public List<Phone> GetPhones(int id)
        {
            return db.Phones.Where(n => n.CustomerId == id&&n.IsDone==true&&n.IsPay==false).ToList();
        }

        public string ReturnInvoiceNumber()
        {
            return db.Invoices.OrderByDescending(n => n.InvoiceId).First().InvoiceNumber;
        }

        public List<Phone> MyPhones(int id)
        {
            return db.Phones.Where(n => n.IsPay == false&&n.CustomerId==id).ToList();
        }

        public DataTable GetReports(int id)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select PhoneID,Model,BarCode,RegDate,EndDate,CustomerId,IsDone,Description,Visit,ProposedPrice,FinalPrice,IsPay from Phones left join  PhoneInvoices on Phones.PhoneID=PhoneInvoices.Phone_PhoneID where Invoice_InvoiceId='{id}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public List<Phone> PhonesUs(int id)
        {
            var res = db.Invoices.Include("Phones").Where(n => n.InvoiceId == id);
            var q = res.Select(n => n.Phones).Single();
            return q;
        }


    }
}
