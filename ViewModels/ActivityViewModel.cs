using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ActivityViewModel
    {
        public int RowId { get; set; }
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string Info { get; set; }
        public string RegDate { get; set; }
    }
}
