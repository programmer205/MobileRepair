using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class UserGroup
    {
        [Key]
        public int Id { get; set; }

        public string Tiltle { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<AccessRole> AccessRoles { get; set; } = new List<AccessRole>();

    }
}
