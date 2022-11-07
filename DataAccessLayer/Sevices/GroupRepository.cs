using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GroupRepository : IUserGroupRepository
    {
        DB db=new DB();
        public bool DeleteGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var res = GetUserGroupById(groupId);
                DeleteGroup(res);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<UserGroup> GetAllUserGroups()
        {
            return db.UserGroups;
        }

        public UserGroup GetUserGroupById(int groupId)
        {
            return db.UserGroups.Find(groupId);
        }

        public bool InsertGroup(UserGroup userGroup)
        {
            try
            {
                db.UserGroups.Add(userGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable ReadBySql()
        {
            string connenct_to = "Data Source=.; Initial Catalog=MobileRapier; Integrated Security=True";
            string query = "select * from UserGroups";
            SqlConnection connection = new SqlConnection(connenct_to);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connenct_to);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool UpdateGroup(UserGroup userGroup)
        {
            try
            {
                db.Entry(userGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<string> GetAllNames()
        {
            return db.UserGroups.Select(n => n.Tiltle).ToList();
        }


        public UserGroup GetGroupByName(string name)
        {
            return db.UserGroups.SingleOrDefault(n => n.Tiltle == name);
        }
    }
}
