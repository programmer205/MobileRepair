using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ReminderViewModel
    {
        public int ReminderId { get; set; }
        public string ReminderTitle { get; set; }
        public string UserName { get; set; }
        public string ReminderInfo { get; set; }
        public string IsDone { get; set; } //ایا یاداور انجام شده است
        public string RegDate { get; set; } //تاریخ ثبت یاداور
        public string RemindDate { get; set; } //تاریخی که باید به ما یاداوری شود
        public int User_Id { get; set; }
    }
}
