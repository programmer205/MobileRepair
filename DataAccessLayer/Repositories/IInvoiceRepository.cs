using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IInvoiceRepository:IDisposable
    {
        IEnumerable<Invoice> GetAllInvoices();

        Invoice GetInvoiceById(int invoiceId);

        bool InsertInvoice(Invoice invoice, List<Phone> phones);

        bool UpdateInvoice(Invoice invoice);

        DataTable GetAllInvoicesBySql();

        DataTable GetInvoiceByName(string name);

        bool DeleteInvoice(Invoice invoice);

        bool DeleteInvoice(int invoiceId);

        void Save();
    }
}
