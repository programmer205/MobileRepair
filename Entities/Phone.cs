using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Phone
    {
        [Key]
        public int PhoneID { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string BarCode { get; set; }

        public DateTime RegDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public bool IsDone { get; set; }

        public bool Visit { get; set; }

        public string Description { get; set; }

        public string ReceptionNumber { get; set; }

        public double ProposedPrice { get; set; }

        public Nullable<double> FinalPrice { get; set; }

        public bool IsPay { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public List<Invoice> Invoices { get; set; }=new List<Invoice>();


    }
}
