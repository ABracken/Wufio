namespace Wufio.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeAndGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        AgeId = c.Int(nullable: false, identity: true),
                        AgeRange = c.String(),
                    })
                .PrimaryKey(t => t.AgeId);
            
            AddColumn("dbo.Animals", "AgeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Gender", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Animals", "AgeId");
            AddForeignKey("dbo.Animals", "AgeId", "dbo.Ages", "AgeId", cascadeDelete: true);
            DropColumn("dbo.Animals", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Age", c => c.String());
            DropForeignKey("dbo.Animals", "AgeId", "dbo.Ages");
            DropIndex("dbo.Animals", new[] { "AgeId" });
            AlterColumn("dbo.Animals", "Gender", c => c.String());
            DropColumn("dbo.Animals", "AgeId");
            DropTable("dbo.Ages");
        }
    }
}
