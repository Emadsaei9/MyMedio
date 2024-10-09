namespace MyMedio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBUP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Karbars",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Karbars");
        }
    }
}
