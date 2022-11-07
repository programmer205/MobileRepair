using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReportRepository : IReportRepository
    {
        public DataTable GetAllActivity(DateTime first, DateTime last)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select ActivityId,Title,(select Name from Users where Users.UserId=Activities.User_id)UserName,(select FullName from Customers where Customers.CustomerId=Activities.Customer_Id)CustomerName,Info,RegDate from Activities where Activities.RegDate between '{first}' and '{last}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetAllCustomers(DateTime first,DateTime last)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select * from Customers where RegDate between '{first}' and '{last}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetAllUsers(DateTime first, DateTime last)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select UserId,Name,UserName,RegDate,(select Tiltle from UserGroups where UserGroups.Id=users.GroupId)Side from Users where users.RegDate between '{first}' and '{last}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable Phones(DateTime first, DateTime last)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select PhoneID,Model,BarCode,RegDate,EndDate,IsDone,Description,Visit,ReceptionNumber,ProposedPrice,(select FullName from Customers where Customers.CustomerId=Phones.CustomerId)CustomerName ,(select PhoneNumber from Customers where Customers.CustomerId=Phones.CustomerId)PhoneNumber,FinalPrice from Phones where Phones.RegDate between '{first}' and '{last}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable Sell(DateTime first, DateTime last)
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = $"select InvoiceId,InvoiceNumber,RegDate,FinalPrice,(select UserName from Users where Users.UserId=Invoices.UserId)UserName,(select FullName from Customers where Customers.CustomerId=Invoices.Customer_id)CustomerName,(select PhoneNumber from Customers where Customers.CustomerId=Invoices.Customer_id)PhoneNumber from Invoices where Invoices.RegDate between '{first}' and '{last}' ";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

    }
}
