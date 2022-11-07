using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; } // مشخص میکنه که آیا کاربر انلاین هست یا خیر
        public DateTime RegDate { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Reminder> Reminders { get; set; } = new List<Reminder>();
        [ForeignKey("UserGroup")]
        public int GroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        public virtual List<Repair> Repairs { get; set; }=new List<Repair>();
    }
}
