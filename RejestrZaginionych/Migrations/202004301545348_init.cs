namespace RejestrZaginionych.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MissingPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        EyeColor = c.String(nullable: false),
                        HairColor = c.String(nullable: false),
                        Height = c.String(nullable: false),
                        MissingDate = c.String(nullable: false),
                        DistinguishingMarks = c.String(),
                        City = c.String(nullable: false),
                        Description = c.String(),
                        AddedByUserId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        MissingPerson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MissingPersons", t => t.MissingPerson_Id)
                .Index(t => t.MissingPerson_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserType = c.Int(nullable: false),
                        Login = c.String(nullable: false, maxLength: 256, unicode: false),
                        Email = c.String(nullable: false, maxLength: 256, unicode: false),
                        Active = c.Boolean(nullable: false),
                        Password = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => new { t.Login, t.Email }, unique: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MissingPersons", "MissingPerson_Id", "dbo.MissingPersons");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Login", "Email" });
            DropIndex("dbo.MissingPersons", new[] { "MissingPerson_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.MissingPersons");
        }
    }
}
