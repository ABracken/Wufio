namespace Wufio.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        AnimalTypeId = c.Int(nullable: false),
                        WufioUserId = c.String(nullable: false, maxLength: 128),
                        Age = c.String(),
                        Gender = c.String(),
                        Breed = c.String(),
                        ImageUrl = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.WufioUserId, cascadeDelete: true)
                .Index(t => t.AnimalTypeId)
                .Index(t => t.WufioUserId);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        AnimalTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.AnimalTypeId);
            
            CreateTable(
                "dbo.UserAnimals",
                c => new
                    {
                        WufioUserId = c.String(nullable: false, maxLength: 128),
                        AnimalId = c.Int(nullable: false),
                        Liked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.WufioUserId, t.AnimalId })
                .ForeignKey("dbo.AspNetUsers", t => t.WufioUserId)
                .ForeignKey("dbo.Animals", t => t.AnimalId)
                .Index(t => t.WufioUserId)
                .Index(t => t.AnimalId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RescueId = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ImageUrl = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rescues", t => t.RescueId)
                .Index(t => t.RescueId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rescues",
                c => new
                    {
                        RescueId = c.Int(nullable: false, identity: true),
                        RescueName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        WebsiteUrl = c.String(),
                        FacebookUrl = c.String(),
                        InstagramUrl = c.String(),
                        TwitterUrl = c.String(),
                        NonProfitLink = c.String(),
                        Notes = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.RescueId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserAnimals", "AnimalId", "dbo.Animals");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "RescueId", "dbo.Rescues");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserAnimals", "WufioUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Animals", "WufioUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Animals", "AnimalTypeId", "dbo.AnimalTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "RescueId" });
            DropIndex("dbo.UserAnimals", new[] { "AnimalId" });
            DropIndex("dbo.UserAnimals", new[] { "WufioUserId" });
            DropIndex("dbo.Animals", new[] { "WufioUserId" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Rescues");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserAnimals");
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Animals");
        }
    }
}
