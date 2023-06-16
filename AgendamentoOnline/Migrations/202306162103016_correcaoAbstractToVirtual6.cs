namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoAbstractToVirtual6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Discriminator", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Discriminator", c => c.String(maxLength: 128));
        }
    }
}
