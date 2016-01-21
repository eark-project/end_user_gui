namespace end_user_gui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderUniqueID = c.String(nullable: false, maxLength: 128),
                        OrderTitle = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        PlannedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderUniqueID);
            
            CreateTable(
                "dbo.OrderArchiveReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Archive_ReferenceCode = c.String(),
                        Archive_AipUri = c.String(),
                        Dissemination_CreatedDate = c.DateTime(nullable: false),
                        LevelOfDescription = c.String(),
                        AccessEndDate = c.DateTime(nullable: false),
                        Status_Status = c.String(),
                        Status_StatusDate = c.DateTime(nullable: false),
                        Order_OrderUniqueID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderUniqueID)
                .Index(t => t.Order_OrderUniqueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderArchiveReferences", "Order_OrderUniqueID", "dbo.Orders");
            DropIndex("dbo.OrderArchiveReferences", new[] { "Order_OrderUniqueID" });
            DropTable("dbo.OrderArchiveReferences");
            DropTable("dbo.Orders");
        }
    }
}
