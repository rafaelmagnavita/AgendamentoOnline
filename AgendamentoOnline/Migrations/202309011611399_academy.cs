namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class academy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "CoachID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "ClientID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "DoctorID");
            DropColumn("dbo.Appointments", "PatientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "PatientID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "DoctorID", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "ClientID");
            DropColumn("dbo.Appointments", "CoachID");
        }
    }
}
