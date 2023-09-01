namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Class : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Appointments");
            DropTable("dbo.Dates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isAvaible = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoachID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        DocConfirm = c.Boolean(nullable: false),
                        PatConfirm = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        ReviewUser = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ScheduleTime = c.DateTime(nullable: false),
                        Motive = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
