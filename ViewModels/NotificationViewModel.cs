using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class NotificationViewModel
    {
        public int RepairId { get; set; }

        public string VisitDate { get; set; }

        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public int PhoneId { get; set; }

        public string PhoneModel { get; set; }

        public string ReceptionNumber { get; set; }
    }
}
