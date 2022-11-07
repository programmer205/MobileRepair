using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class InvoiceViewModel
    {
        public int RowId { get; set; }
        public int InvoiceId { get; set; }

        public string InvoiceNumber { get; set; }

        public string RegDate { get; set; }

        public string FinalPrice { get; set; }

        public string UserName { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
