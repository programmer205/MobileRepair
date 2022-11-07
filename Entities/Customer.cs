using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        
        public DateTime RegDate { get; set; }

        public List<Phone> Phones { get; set; }=new List<Phone>();

        public List<Activity> Activities { get; set; }=new List<Activity>();

        public List<Invoice> Invoices { get; set; }=new List<Invoice>();

        public List<Repair> Repairs { get; set; }=new List<Repair>();

    }
}
