namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uruntabloguncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunler", "aktif", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Urunler", "aktif");
        }
    }
}
