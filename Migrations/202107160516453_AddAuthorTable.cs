namespace IntellectsPodium2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                {
                    AuthorId = c.Int(nullable: false, identity: true),
                    AuthorName = c.String(),
                })
                .PrimaryKey(t => t.AuthorId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Authors");
        }
    }
}
