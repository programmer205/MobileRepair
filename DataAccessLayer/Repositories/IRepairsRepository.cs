using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IRepairsRepository:IDisposable
    {
        IEnumerable<Repair> GetAllRepairs();

        Repair GetRepairById(int id);

        bool InsertRepair(Repair repair);

        bool UpdateRepair(Repair repair);

        bool DeleteRepair(Repair repair);

        bool DeleteRepair(int id);

        DataTable GetAllRepairsBySql();

        DataTable GetRepairByName();

        void Save();
    }
}
