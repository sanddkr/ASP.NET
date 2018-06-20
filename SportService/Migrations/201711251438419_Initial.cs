namespace SportService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        student_number = c.String(nullable: false, maxLength: 128),
                        student_firstname = c.String(nullable: false),
                        student_lastname = c.String(nullable: false),
                        type_of_sport = c.String(nullable: false, maxLength: 128),
                        birthday = c.DateTime(nullable: false),
                        height = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.student_number)
                .ForeignKey("dbo.Teams", t => t.type_of_sport, cascadeDelete: true)
                .Index(t => t.type_of_sport);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        type_of_sport = c.String(nullable: false, maxLength: 128),
                        coach_name = c.String(nullable: false),
                        season = c.String(),
                        fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.type_of_sport);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "type_of_sport", "dbo.Teams");
            DropIndex("dbo.Athletes", new[] { "type_of_sport" });
            DropTable("dbo.Teams");
            DropTable("dbo.Athletes");
        }
    }
}
