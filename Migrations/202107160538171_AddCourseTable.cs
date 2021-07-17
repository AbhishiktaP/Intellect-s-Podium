namespace IntellectsPodium2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTable : DbMigration
    {
        public override void Up()
        {
            
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        Level = c.String(),
                        DescriptionLong = c.String(),
                        DescriptionBrief = c.String(),
                        Cost = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Authors", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CourseId", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "CourseId" });
            DropTable("dbo.Courses");
            
        }
    }
}
