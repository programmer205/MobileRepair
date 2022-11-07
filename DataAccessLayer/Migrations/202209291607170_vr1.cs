namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessRoles",
                c => new
                    {
                        AccessRoleId = c.Int(nullable: false, identity: true),
                        Section = c.String(),
                        CanEnter = c.Boolean(nullable: false),
                        CanCreate = c.Boolean(nullable: false),
                        CanUpdate = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessRoleId)
                .ForeignKey("dbo.UserGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tiltle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Picture = c.String(),
                        PhoneNumber = c.String(),
                        Status = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Info = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        User_id = c.Int(nullable: false),
                        Customer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id)
                .Index(t => t.Customer_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        IsCheck = c.Boolean(nullable: false),
                        CheckOutDate = c.DateTime(),
                        FinalPrice = c.String(),
                        Customer_id = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneID = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false),
                        BarCode = c.String(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsDone = c.Boolean(nullable: false),
                        Visit = c.Boolean(nullable: false),
                        Description = c.String(),
                        ReceptionNumber = c.String(),
                        ProposedPrice = c.Double(nullable: false),
                        FinalPrice = c.Double(),
                        IsPay = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        RepairId = c.Int(nullable: false, identity: true),
                        VisitDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Customer_id = c.Int(nullable: false),
                        User_id = c.Int(nullable: false),
                        P_id = c.Int(),
                    })
                .PrimaryKey(t => t.RepairId)
                .ForeignKey("dbo.Customers", t => t.Customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Phones", t => t.P_id)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.Customer_id)
                .Index(t => t.User_id)
                .Index(t => t.P_id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Int(nullable: false, identity: true),
                        ReminderTitle = c.String(),
                        ReminderInfo = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        RemindDate = c.DateTime(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReminderId)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MyBackups",
                c => new
                    {
                        BackupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.BackupId);
            
            CreateTable(
                "dbo.MyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneInvoices",
                c => new
                    {
                        Phone_PhoneID = c.Int(nullable: false),
                        Invoice_InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Phone_PhoneID, t.Invoice_InvoiceId })
                .ForeignKey("dbo.Phones", t => t.Phone_PhoneID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId, cascadeDelete: true)
                .Index(t => t.Phone_PhoneID)
                .Index(t => t.Invoice_InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessRoles", "GroupId", "dbo.UserGroups");
            DropForeignKey("dbo.Users", "GroupId", "dbo.UserGroups");
            DropForeignKey("dbo.Reminders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Activities", "User_id", "dbo.Users");
            DropForeignKey("dbo.Activities", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Repairs", "User_id", "dbo.Users");
            DropForeignKey("dbo.Repairs", "P_id", "dbo.Phones");
            DropForeignKey("dbo.Repairs", "Customer_id", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "UserId", "dbo.Users");
            DropForeignKey("dbo.PhoneInvoices", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.PhoneInvoices", "Phone_PhoneID", "dbo.Phones");
            DropForeignKey("dbo.Phones", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "Customer_id", "dbo.Customers");
            DropIndex("dbo.PhoneInvoices", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.PhoneInvoices", new[] { "Phone_PhoneID" });
            DropIndex("dbo.Reminders", new[] { "User_Id" });
            DropIndex("dbo.Repairs", new[] { "P_id" });
            DropIndex("dbo.Repairs", new[] { "User_id" });
            DropIndex("dbo.Repairs", new[] { "Customer_id" });
            DropIndex("dbo.Phones", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "Customer_id" });
            DropIndex("dbo.Activities", new[] { "Customer_id" });
            DropIndex("dbo.Activities", new[] { "User_id" });
            DropIndex("dbo.Users", new[] { "GroupId" });
            DropIndex("dbo.AccessRoles", new[] { "GroupId" });
            DropTable("dbo.PhoneInvoices");
            DropTable("dbo.MyInformations");
            DropTable("dbo.MyBackups");
            DropTable("dbo.Reminders");
            DropTable("dbo.Repairs");
            DropTable("dbo.Phones");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Activities");
            DropTable("dbo.Users");
            DropTable("dbo.UserGroups");
            DropTable("dbo.AccessRoles");
        }
    }
}
