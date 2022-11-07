using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IActivityRepository:IDisposable
    {
        IEnumerable<Activity> GetAllActivities();

        Activity GetActivityById(int activityId);

        bool InsertActivity(Activity activity);

        bool UpdateActivity(Activity activity);

        DataTable GetAllActivitiesBySql();

        DataTable GetActivityByName(string name);

        bool DeleteActivity(Activity activity);

        bool DeleteActivity(int activityId);

        void Save();
    }
}
