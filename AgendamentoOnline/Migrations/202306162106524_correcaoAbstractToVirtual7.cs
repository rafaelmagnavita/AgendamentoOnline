namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoAbstractToVirtual7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Type", c => c.Int(nullable: false));
        }
    }
}
