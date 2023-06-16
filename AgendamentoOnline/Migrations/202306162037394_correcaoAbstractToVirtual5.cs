namespace AgendamentoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoAbstractToVirtual5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Users1");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Identification", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Specialization", c => c.Int());
            AlterColumn("dbo.Users", "Discriminator", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "HealthInsurance", c => c.Int());
            AlterColumn("dbo.Users", "MotherName", c => c.String());
            AlterColumn("dbo.Users", "FatherName", c => c.String());
            AlterColumn("dbo.Users", "Birth", c => c.DateTime());
            AddPrimaryKey("dbo.Users", "Id");
            DropTable("dbo.Users1");
        }
        
        public override void Down()
        {
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
            
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Birth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "FatherName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "MotherName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "HealthInsurance", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "Specialization", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Type");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Identification");
            DropColumn("dbo.Users", "Name");
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Users1", "Id");
        }
    }
}
