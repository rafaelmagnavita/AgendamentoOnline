namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Class2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        LinkLive = c.String(),
                        LinkRecorded = c.String(),
                        Time = c.DateTime(nullable: false),
                        CoachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classes");
        }
    }
}
