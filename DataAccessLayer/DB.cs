using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class DB:DbContext
    {
        public DB() : base("connect")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<AccessRole> AccessRoles { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<MyInformation> MyInformation { get; set; }
        public DbSet<MyBackup> MyBackups { get; set; }
    }
}
