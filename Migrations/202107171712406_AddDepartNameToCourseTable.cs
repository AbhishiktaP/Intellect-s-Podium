namespace IntellectsPodium2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartNameToCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DepartmentName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DepartmentName");
        }
    }
}
