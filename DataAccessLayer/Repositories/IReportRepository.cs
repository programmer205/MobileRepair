using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IReportRepository
    {
        DataTable GetAllCustomers(DateTime first,DateTime last);

        DataTable GetAllUsers(DateTime first, DateTime last);

        DataTable GetAllActivity(DateTime first, DateTime last);

        DataTable Sell(DateTime first, DateTime last);

        DataTable Phones(DateTime first, DateTime last);
    }
}
