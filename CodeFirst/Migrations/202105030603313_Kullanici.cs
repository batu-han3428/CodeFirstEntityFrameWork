namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kullanici : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kullaniciGiris",
                c => new
                    {
                        kullaniciId = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        sifre = c.String(),
                    })
                .PrimaryKey(t => t.kullaniciId);
            
            CreateTable(
                "dbo.kullaniciDiger",
                c => new
                    {
                        kullaniciId = c.Int(nullable: false),
                        iletisim = c.String(),
                        adres = c.String(),
                    })
                .PrimaryKey(t => t.kullaniciId)
                .ForeignKey("dbo.kullaniciGiris", t => t.kullaniciId)
                .Index(t => t.kullaniciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.kullaniciDiger", "kullaniciId", "dbo.kullaniciGiris");
            DropIndex("dbo.kullaniciDiger", new[] { "kullaniciId" });
            DropTable("dbo.kullaniciDiger");
            DropTable("dbo.kullaniciGiris");
        }
    }
}
