using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public string Title { get; set; }
        
        public string Info { get; set; }
        
        public DateTime RegDate { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int User_id { get; set; }

        public virtual Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int Customer_id { get; set; }
    }
}
