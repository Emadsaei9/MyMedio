namespace MyMedio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        TazrighID = c.Int(nullable: false, identity: true),
                        BimarID = c.Int(nullable: false),
                        HajmeTazrigh = c.String(nullable: false, maxLength: 250),
                        GelzatTazrigh = c.String(nullable: false, maxLength: 250),
                        NaghsJenetik = c.String(),
                        NoeTazrigh = c.String(),
                        Comision = c.String(),
                        ElatTzrigh = c.String(nullable: false),
                        SabegheGhabli = c.String(nullable: false),
                        SabegheDarman = c.String(nullable: false),
                        SabegheFamily = c.String(nullable: false),
                        SharhHal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TazrighID)
                .ForeignKey("dbo.Sicks", t => t.BimarID, cascadeDelete: true)
                .Index(t => t.BimarID);
            
            CreateTable(
                "dbo.Sicks",
                c => new
                    {
                        BimarID = c.Int(nullable: false, identity: true),
                        GrohBimariID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        NameBimar = c.String(nullable: false, maxLength: 250),
                        FamilBimar = c.String(nullable: false, maxLength: 250),
                        Codemeli = c.Int(nullable: false),
                        NamePedar = c.String(nullable: false, maxLength: 250),
                        Moteahel = c.String(),
                        Farzand = c.String(),
                        TedadFarzand = c.String(),
                        RezayatName = c.String(),
                        ImageNameRezayat = c.String(),
                    })
                .PrimaryKey(t => t.BimarID)
                .ForeignKey("dbo.sickGroups", t => t.GrohBimariID, cascadeDelete: true)
                .Index(t => t.GrohBimariID);
            
            CreateTable(
                "dbo.sickGroups",
                c => new
                    {
                        GrohBimariID = c.Int(nullable: false, identity: true),
                        GroupBimariTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GrohBimariID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sicks", "GrohBimariID", "dbo.sickGroups");
            DropForeignKey("dbo.Documents", "BimarID", "dbo.Sicks");
            DropIndex("dbo.Sicks", new[] { "GrohBimariID" });
            DropIndex("dbo.Documents", new[] { "BimarID" });
            DropTable("dbo.sickGroups");
            DropTable("dbo.Sicks");
            DropTable("dbo.Documents");
        }
    }
}
