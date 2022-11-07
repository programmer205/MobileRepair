using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Utility;
using ViewModels;

namespace BusinessLogicLayer
{
    public class DashboardCrud:IDisposable
    {
        DashboardRepository db=new DashboardRepository();
        public List<NotificationViewModel> GetRepairsForMe(int id)
        {
            List<NotificationViewModel> Alarms=new List<NotificationViewModel>();
            foreach (DataRow item in db.GetRepairForMe(id).Rows)
            {
                if (Convert.ToBoolean(item[7]) == false)
                {
                    Alarms.Add(new NotificationViewModel()
                    {
                        RepairId = int.Parse(item[0].ToString()),
                        VisitDate = Convert.ToDateTime(item[1]).Shamsi(),
                        CustomerId = int.Parse(item[2].ToString()),
                        UserId = int.Parse(item[3].ToString()),
                        PhoneId = int.Parse(item[4].ToString()),
                        PhoneModel = item[5].ToString(),
                        ReceptionNumber = item[6].ToString()
                    });
                }
            }

            return Alarms;
        }

        private string Encode(string pass)
        {
            byte[] end_Data_byte = new byte[pass.Length];
            end_Data_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string EnCodeData = Convert.ToBase64String(end_Data_byte);
            return EnCodeData;
        }

        private string Dicode(string encoded)
        {
            System.Text.UTF8Encoding Encoder = new UTF8Encoding();
            System.Text.Decoder decoder = Encoder.GetDecoder();
            byte[] todecodeBytes = Convert.FromBase64String(encoded);
            int charcount = decoder.GetCharCount(todecodeBytes, 0, todecodeBytes.Length);
            char[] decoded_char = new char[charcount];
            decoder.GetChars(todecodeBytes, 0, todecodeBytes.Length, decoded_char, 0);
            string Result = new string(decoded_char);
            return Result;
        }

        public bool Check()
        {
            return db.Check();
        }

        public bool CreateInfo(MyInformation information)
        {
            try
            {
                information.Password = Encode(information.Password);
                db.InsertInfo(information);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MyInformation GetInfo()
        {
            if (db.GetInfo() != null)
            {
                var res = db.GetInfo();
                res.Password = Dicode(res.Password);
                return res;
            }
            else
            {
                return db.GetInfo();
            }
        }


        public bool EditInfo(MyInformation information)
        {
            DashboardRepository dr=new DashboardRepository();
            try
            {
                information.Password = Encode(information.Password);
                dr.UpdateInfo(information);
                dr.Save();
                dr.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string name,int id)
        {
            var code = Encode(name);
            return db.update(code,id);
        }

        public MyInformation GetInfoByUser(string name)
        {
            return db.GetInfoByUser(name);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public int GetCountOfReminder(int id)
        {
            return db.GetCountOfReminder(id);
        }

        public int GetCountOfRepair(int id)
        {
            return db.GetCountOfRepair(id);
        }

        public int GetCustomerCount()
        {
            return db.GetCountOfCustomers();
        }

        public List<Reminder> GetReminders(int id)
        {
            return db.GetReminders(id);
        }
    }
}
