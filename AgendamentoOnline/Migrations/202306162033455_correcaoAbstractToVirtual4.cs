namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoAbstractToVirtual4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Users1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Identification = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Specialization", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "HealthInsurance", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "MotherName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FatherName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Birth", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Users1", "Id");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Identification");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Identification", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Users", "Id", "dbo.Users1");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Birth", c => c.DateTime());
            AlterColumn("dbo.Users", "FatherName", c => c.String());
            AlterColumn("dbo.Users", "MotherName", c => c.String());
            AlterColumn("dbo.Users", "HealthInsurance", c => c.Int());
            AlterColumn("dbo.Users", "Specialization", c => c.Int());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Users1");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
