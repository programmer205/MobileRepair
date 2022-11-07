using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class AccessRole
    {
        [Key]
        public int AccessRoleId { get; set; }

        public string Section { get; set; }

        public bool CanEnter { get; set; }

        public bool CanCreate { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public UserGroup UserGroup { get; set; }
        [ForeignKey("UserGroup")]
        public int GroupId { get; set; }
    }
}
