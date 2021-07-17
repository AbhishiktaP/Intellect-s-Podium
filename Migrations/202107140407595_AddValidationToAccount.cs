namespace IntellectsPodium2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToAccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "FirstName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Accounts", "LastName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Accounts", "Qualification", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Accounts", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Qualification", c => c.String());
            AlterColumn("dbo.Accounts", "LastName", c => c.String());
            AlterColumn("dbo.Accounts", "FirstName", c => c.String());
        }
    }
}
