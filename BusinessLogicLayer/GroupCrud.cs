using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class GroupCrud:IDisposable
    {
        GroupRepository db=new GroupRepository();
        public bool Create(UserGroup userGroup)
        {
            try
            {
                db.InsertGroup(userGroup);
                db.Save();
                db.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UserGroup> Read()
        {
            List<UserGroup> groups = new List<UserGroup>();
            foreach (DataRow item in db.ReadBySql().Rows)
            {
                groups.Add(new UserGroup()
                {
                    Id = int.Parse(item[0].ToString()),
                    Tiltle = item[1].ToString()
                });
            }

            return groups;
        }
        public List<string> GetAllNames()
        {
            return db.GetAllNames();
        }

        public UserGroup GetGroupByName(string name)
        {
            return db.GetGroupByName(name);
        }

        public UserGroup Find(int id)
        {
            return db.GetUserGroupById(id);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
