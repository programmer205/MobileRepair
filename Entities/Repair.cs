using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }

        public DateTime VisitDate { get; set; }

        public Nullable<DateTime> EndDate { get; set; }

        public virtual Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int Customer_id { get; set; }

        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }

        public virtual Phone Phone { get; set; }
        [ForeignKey("Phone")]
        public Nullable<int> P_id { get; set; }

    }
}
