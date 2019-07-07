namespace Vet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Hour = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ClientId = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Appointment", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Patient", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.Patient", new[] { "ClientId" });
            DropIndex("dbo.Appointment", new[] { "RoomId" });
            DropIndex("dbo.Appointment", new[] { "PatientId" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropTable("dbo.Room");
            DropTable("dbo.Client");
            DropTable("dbo.Patient");
            DropTable("dbo.Doctor");
            DropTable("dbo.Appointment");
        }
    }
}
