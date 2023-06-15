namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ReviewUser = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ScheduleTime = c.DateTime(nullable: false),
                        Motive = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                        Identification = c.String(),
                        Specialization = c.Int(),
                        Name1 = c.String(),
                        Identification1 = c.String(),
                        HealthInsurance = c.Int(),
                        MotherName = c.String(),
                        FatherName = c.String(),
                        Birth = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Dates");
            DropTable("dbo.Appointments");
        }
    }
}
