using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PhoneViewModel
    {
        public int RowId { get; set; }
        public int PhoneID { get; set; }

        public string Model { get; set; }

        
        public string BarCode { get; set; }

        public string RegDate { get; set; }

        public string EndDate { get; set; }

        public string IsDone { get; set; }

        public string Description { get; set; }
        
        public string Visit { get; set; }

        public string ReceptionNumber { get; set; }

        public string Price { get; set; }
        
        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }

    }
}
