using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class BackupRepository
    {
        DB db = new DB();
        public bool Backup(string path, string name)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=CRMdb; Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $@"backup database CRMdb to disk='{path}\{name}.bak'";
                command.ExecuteNonQuery();
                connection.Close();
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
                SqlConnection connection = new SqlConnection("Data Source=.; Initial Catalog=CRMdb; Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"restore database master from disk='{path}' with replace";
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool InsertBackup(MyBackup myBackup)
        {
            try
            {
                db.MyBackups.Add(myBackup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<MyBackup> GetAllBackups()
        {
            return db.MyBackups.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
