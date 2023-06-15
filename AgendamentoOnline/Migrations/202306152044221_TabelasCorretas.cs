namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasCorretas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Identification", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Name1");
            DropColumn("dbo.Users", "Identification1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Identification1", c => c.String());
            AddColumn("dbo.Users", "Name1", c => c.String());
            AlterColumn("dbo.Users", "Identification", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
