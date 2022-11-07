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
    public class ReportCrud
    {
        ReportRepository db=new ReportRepository();
        public List<CustomerViewModel> GetAllCustomers(DateTime first, DateTime last)
        {
            List<CustomerViewModel>customers=new List<CustomerViewModel>();
            int sum = 1;
            foreach (DataRow item in db.GetAllCustomers(first,last).Rows)
            {
                customers.Add(new CustomerViewModel()
                {
                    RowId = sum,
                    CustomerId = int.Parse(item[0].ToString()),
                    FullName = item[1].ToString(),
                    PhoneNumber = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi()
                });
                sum++;
            }

            return customers;
        }
        public List<ActivityViewModel> GetAllActivity(DateTime first, DateTime last)
        {
            List<ActivityViewModel> activities = new List<ActivityViewModel>();
            int sum = 1;
            foreach (DataRow item in db.GetAllActivity(first,last).Rows)
            {
                activities.Add(new ActivityViewModel()
                {
                    RowId = sum,
                    ActivityId = int.Parse(item[0].ToString()),
                    Title = item[1].ToString(),
                    UserName = item[2].ToString(),
                    CustomerName = item[3].ToString(),
                    Info = item[4].ToString(),
                    RegDate = Convert.ToDateTime(item[5]).Shamsi()
                });
                sum++;
            }

            return activities;
        }

        public List<InvoiceViewModel> GetAllInvoices(DateTime first, DateTime last)
        {
            List<InvoiceViewModel> invoices = new List<InvoiceViewModel>();
            string a = "";
            int sum = 1;
            foreach (DataRow item in db.Sell(first,last).Rows)
            {
                invoices.Add(new InvoiceViewModel()
                {
                    RowId = sum,
                    InvoiceId = int.Parse(item[0].ToString()),
                    InvoiceNumber = item[1].ToString(),
                    RegDate = Convert.ToDateTime(item[2]).Shamsi(),
                    FinalPrice = Convert.ToDouble(item[3].ToString()).ToString("N0"),
                    UserName = item[4].ToString(),
                    CustomerName = item[5].ToString(),
                    PhoneNumber = item[6].ToString()
                });
                sum++;
            }

            return invoices;
        }


        public List<PhoneViewModel> GetAllPhones(DateTime first, DateTime last)
        {
            List<PhoneViewModel> Phones = new List<PhoneViewModel>();
            string Text = "";
            string visit = "";
            string end = "---";
            int sum = 1;
            foreach (DataRow item in db.Phones(first,last).Rows)
            {
                if (Convert.ToBoolean(item[5]) == true)
                {
                    Text = "تعمیر شده";
                }
                else
                {
                    Text = "در حال تعمیر";
                }

                if (Convert.ToBoolean(item[7]))
                {
                    visit = "ویزیت شده";
                }
                else
                {
                    visit = "ویزیت نشده";
                }

                if (item[4] == null)
                {
                    end = Convert.ToDateTime(item[4]).Shamsi();
                }
                else
                {
                    end = "----";
                }
                Phones.Add(new PhoneViewModel()
                {
                    RowId = sum,
                    PhoneID = int.Parse(item[0].ToString()),
                    Model = item[1].ToString(),
                    BarCode = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi(),
                    EndDate = end,
                    IsDone = Text,
                    Description = item[6].ToString(),
                    Visit = visit,
                    ReceptionNumber = item[8].ToString(),
                    Price = double.Parse(item[9].ToString()).ToString("N0"),
                    CustomerName = item[10].ToString(),
                    PhoneNumber = item[11].ToString()
                });
                sum++;
            }

            return Phones;
        }

        public List<UserReportView> GetAllUsers(DateTime first,DateTime last)
        {
            List<UserReportView> report=new List<UserReportView>();
            int sum = 1;
            foreach (DataRow item in db.GetAllUsers(first,last).Rows)
            {
                report.Add(new UserReportView()
                {
                    UserId = int.Parse(item[0].ToString()),
                    RowId = sum,
                    Name = item[1].ToString(),
                    UserName = item[2].ToString(),
                    RegDate = Convert.ToDateTime(item[3]).Shamsi(),
                    Side = item[4].ToString()
                });
                sum++;
            }

            return report;
        }
    }
}
