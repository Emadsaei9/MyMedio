namespace MyMedio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grohbimari : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sicks", "GroupBimariTitle", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sicks", "GroupBimariTitle");
        }
    }
}
