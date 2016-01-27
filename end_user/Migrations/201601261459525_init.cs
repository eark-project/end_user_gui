namespace end_user_gui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EndUsers",
                c => new
                    {
                        UniqueId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UniqueId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderUniqueID = c.String(nullable: false, maxLength: 128),
                        OrderTitle = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        PlannedDate = c.DateTime(),
                        ExpectedReadyDate_Date = c.DateTime(),
                        ExpectedReadyDate_Text = c.String(),
                        User_UniqueId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderUniqueID)
                .ForeignKey("dbo.EndUsers", t => t.User_UniqueId)
                .Index(t => t.User_UniqueId);
            
            CreateTable(
                "dbo.OrderArchiveReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Archive_ReferenceCode = c.String(),
                        Archive_AipUri = c.String(),
                        LevelOfDescription = c.String(),
                        AccessEndDate = c.DateTime(),
                        Status_Status = c.String(),
                        Status_StatusDate = c.DateTime(),
                        AccessRestriction_Code = c.Int(nullable: false),
                        AccessRestriction_Text = c.String(),
                        Order_OrderUniqueID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderUniqueID)
                .Index(t => t.Order_OrderUniqueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UniqueId", "dbo.EndUsers");
            DropForeignKey("dbo.OrderArchiveReferences", "Order_OrderUniqueID", "dbo.Orders");
            DropIndex("dbo.OrderArchiveReferences", new[] { "Order_OrderUniqueID" });
            DropIndex("dbo.Orders", new[] { "User_UniqueId" });
            DropTable("dbo.OrderArchiveReferences");
            DropTable("dbo.Orders");
            DropTable("dbo.EndUsers");
        }
    }
}
