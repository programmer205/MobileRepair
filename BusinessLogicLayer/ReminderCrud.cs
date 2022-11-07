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
    public class ReminderCrud
    {
        ReminderRepository db=new ReminderRepository();
        UserRepository ur=new UserRepository();
        public bool Create(Reminder reminder)
        {
            try
            {
                db.InsertReminder(reminder);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> GetAllNames()
        {
            return ur.GetAllNames();
        }

        public List<ReminderViewModel> Read()
        {
            List<ReminderViewModel> Reminders=new List<ReminderViewModel>();
            string text = "";
            foreach (DataRow item in db.GetAllRemindersBySql().Rows)
            {
                if (Convert.ToBoolean(item[4]))
                {
                    text = "انجام شده";
                }
                else
                {
                    text = "انجام نشده";
                }
                Reminders.Add(new ReminderViewModel()
                {
                    ReminderId = int.Parse(item[0].ToString()),
                    ReminderTitle = item[1].ToString(),
                    UserName =item[2].ToString(),
                    ReminderInfo = item[3].ToString(),
                    IsDone = text,
                    RegDate = Convert.ToDateTime(item[5]).Shamsi(),
                    RemindDate = Convert.ToDateTime(item[6]).Shamsi(),
                    User_Id = int.Parse(item[7].ToString())
                });
            }

            return Reminders;
        }

        public bool Edit(Reminder reminder)
        {
            try
            {
                db.UpdateReminder(reminder);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.DeleteReminder(id);
                db.Save();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int FindUserByName(string name)
        {
            return ur.FindIdByUserName(name);
        }

        public Reminder Find(int id)
        {
            return db.GetReminderById(id);
        }

        public string back(int id)
        {
            ReminderRepository db = new ReminderRepository();
            return db.GetName(id);
        }

        public List<ReminderViewModel> ReadByName(string name)
        {
            List<ReminderViewModel> Reminders = new List<ReminderViewModel>();
            string text = "";
            foreach (DataRow item in db.GetReminderByName(name).Rows)
            {
                if (Convert.ToBoolean(item[4]))
                {
                    text = "انجام شده";
                }
                else
                {
                    text = "انجام نشده";
                }
                Reminders.Add(new ReminderViewModel()
                {
                    ReminderId = int.Parse(item[0].ToString()),
                    ReminderTitle = item[1].ToString(),
                    UserName = item[2].ToString(),
                    ReminderInfo = item[3].ToString(),
                    IsDone = text,
                    RegDate = Convert.ToDateTime(item[5]).Shamsi(),
                    RemindDate = Convert.ToDateTime(item[6]).Shamsi(),
                    User_Id = int.Parse(item[7].ToString())
                });
            }

            return Reminders;
        }

        public void Update(int id)
        {
            var res = Find(id);
            res.IsDone = true;
            Edit(res);
        }
    }
}
