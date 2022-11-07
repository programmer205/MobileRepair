using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RepairViewModel
    {
        public int RepairId { get; set; }

        public string ReceptionNumber { get; set; }

        public string Model { get; set; }

        public string BarCode { get; set; }

        public string RegDate { get; set; }

        public string Description { get; set; }

        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneId { get; set; }
    }
}
