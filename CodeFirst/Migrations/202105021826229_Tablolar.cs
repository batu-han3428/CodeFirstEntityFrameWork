namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablolar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        kategoriAd = c.String(maxLength: 50),
                        kategoriAciklama = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        urunId = c.Int(nullable: false, identity: true),
                        urunAd = c.String(maxLength: 50),
                        urunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        urunStok = c.Int(),
                        kategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.urunId)
                .ForeignKey("dbo.Kategoriler", t => t.kategoriId, cascadeDelete: true)
                .Index(t => t.kategoriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Urunler", "kategoriId", "dbo.Kategoriler");
            DropIndex("dbo.Urunler", new[] { "kategoriId" });
            DropTable("dbo.Urunler");
            DropTable("dbo.Kategoriler");
        }
    }
}
