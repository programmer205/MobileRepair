using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public interface IUserGroupRepository:IDisposable
    {
        IEnumerable<UserGroup> GetAllUserGroups();

        UserGroup GetUserGroupById(int groupId);

        bool InsertGroup(UserGroup userGroup);

        bool UpdateGroup(UserGroup userGroup);

        bool DeleteGroup(UserGroup userGroup);

        bool DeleteGroup(int groupId);

        DataTable ReadBySql();

        void Save();
    }
}
