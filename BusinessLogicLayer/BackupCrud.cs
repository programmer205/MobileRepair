using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class BackupCrud
    {
        BackupRepository db = new BackupRepository();
        public bool Backup(string path, string name)
        {
            try
            {
                db.Backup(path, name);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Restore(string path)
        {
            try
            {
                db.Restore(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Create(MyBackup myBackup)
        {
            try
            {
                db.InsertBackup(myBackup);
                db.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MyBackup> GetAllBackups()
        {
            return db.GetAllBackups();
        }
    }
}
