using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IReminderRepository:IDisposable
    {
        IEnumerable<Reminder> GetAllReminders();

        Reminder GetReminderById(int reminderId);

        bool InsertReminder(Reminder reminder);

        bool UpdateReminder(Reminder reminder);

        bool DeleteReminder(Reminder reminder);

        bool DeleteReminder(int reminderId);

        DataTable GetReminderByName(string name);

        DataTable GetAllRemindersBySql();

        void Save();
    }
}
