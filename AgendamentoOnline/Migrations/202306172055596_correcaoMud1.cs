namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoMud1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DocConfirm", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "PatConfirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PatConfirm");
            DropColumn("dbo.Appointments", "DocConfirm");
        }
    }
}
