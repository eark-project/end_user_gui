namespace end_user_gui.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status_Status", c => c.Int());
            AddColumn("dbo.Orders", "Status_StatusDate", c => c.DateTime());
            AlterColumn("dbo.OrderArchiveReferences", "Status_Status", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderArchiveReferences", "Status_Status", c => c.String());
            DropColumn("dbo.Orders", "Status_StatusDate");
            DropColumn("dbo.Orders", "Status_Status");
        }
    }
}
