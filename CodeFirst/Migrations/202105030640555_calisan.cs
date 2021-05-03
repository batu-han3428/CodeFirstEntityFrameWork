namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calisan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calisanlar",
                c => new
                    {
                        calisanId = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        soyad = c.String(),
                        ccinsiyet = c.String(),
                        mail = c.String(),
                        telefon = c.String(),
                    })
                .PrimaryKey(t => t.calisanId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Calisanlar");
        }
    }
}
