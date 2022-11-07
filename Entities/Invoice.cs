using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } // شماره فاکتور
        public DateTime RegDate { get; set; } // تاریخ صدور فاکتور
        public bool IsCheck { get; set; } //ایا فاکتور تصفیه شده یا خیر
        public Nullable<DateTime> CheckOutDate { get; set; } //تاریخ تصفیه شدن فاکتور
        public string FinalPrice { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public Nullable<int> Customer_id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();

    }
}
