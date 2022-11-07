using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
   public static class Converter
    {
        public static string ToShamsi(this DateTime time)
        {
            PersianCalendar pc=new PersianCalendar();

            return pc.GetYear(time) + "/" + pc.GetMonth(time) + "/" + pc.GetDayOfMonth(time) + "  " + pc.GetHour(time) +
                   ":" + pc.GetMinute(time) + ":" + pc.GetSecond(time);
        }

        public static string Shamsi(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(time) + "/" + pc.GetMonth(time) + "/" + pc.GetDayOfMonth(time);
        }

        public static string ToSHAMSI(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(time) + "/" + pc.GetMonth(time) + "/" + pc.GetDayOfMonth(time) + "  " + pc.GetHour(time) +
                   ":" + pc.GetMinute(time);
        }
    }
}
