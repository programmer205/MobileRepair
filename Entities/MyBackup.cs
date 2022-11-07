﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MyBackup
    {
        [Key]
        public int BackupId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
