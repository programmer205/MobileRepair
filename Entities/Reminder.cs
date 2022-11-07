using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }
        public string ReminderTitle { get; set; }
        public string ReminderInfo { get; set; }
        public bool IsDone { get; set; } //ایا یاداور انجام شده است
        public DateTime RegDate { get; set; } //تاریخ ثبت یاداور
        public DateTime RemindDate { get; set; } //تاریخی که باید به ما یاداوری شود
        [ForeignKey("User")]
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
