namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ogrenciOgretmenAraTablo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        ogrenciId = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                    })
                .PrimaryKey(t => t.ogrenciId);
            
            CreateTable(
                "dbo.Ogretmen",
                c => new
                    {
                        ogretmenId = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                    })
                .PrimaryKey(t => t.ogretmenId);
            
            CreateTable(
                "dbo.OgrencilerOgretmenler",
                c => new
                    {
                        ogrenciid = c.Int(nullable: false),
                        ogretmenid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ogrenciid, t.ogretmenid })
                .ForeignKey("dbo.Ogrencis", t => t.ogrenciid, cascadeDelete: true)
                .ForeignKey("dbo.Ogretmen", t => t.ogretmenid, cascadeDelete: true)
                .Index(t => t.ogrenciid)
                .Index(t => t.ogretmenid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrencilerOgretmenler", "ogretmenid", "dbo.Ogretmen");
            DropForeignKey("dbo.OgrencilerOgretmenler", "ogrenciid", "dbo.Ogrencis");
            DropIndex("dbo.OgrencilerOgretmenler", new[] { "ogretmenid" });
            DropIndex("dbo.OgrencilerOgretmenler", new[] { "ogrenciid" });
            DropTable("dbo.OgrencilerOgretmenler");
            DropTable("dbo.Ogretmen");
            DropTable("dbo.Ogrencis");
        }
    }
}
