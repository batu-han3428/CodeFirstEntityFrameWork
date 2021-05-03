using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.Models;

namespace CodeFirst.Context
{
    public class dbContext:DbContext
    {
        public dbContext()
        {
            Database.Connection.ConnectionString = 
     @"Data Source=(LocalDb)\MsSqlLocalDb;Initial Catalog=CodeFirst;Integrated Security=true;";
        }

        public DbSet<Kategori> kategoriler { get; set; }//bire çok ilişki
        public DbSet<Urun> urunler { get; set; }//bire çok ilişki
        public DbSet<Kullanici> kullanıcılar { get; set; }//Entity Splitting(class ikiye bölmek)
        public DbSet<Calisan> calisanlar { get; set; }//Table Splitting(2 classı birleştirmek)
        public DbSet<Ogrenci> ogrenciler { get; set; }//çoka çok ilişki
        public DbSet<Ogretmen> ogretmenler { get; set; }//çoka çok ilişki
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            kullaniciBol(modelBuilder);
            calisanBirlestir(modelBuilder);
            cokaCokİliski(modelBuilder);
            aktifpasif(modelBuilder);
        }

        private void aktifpasif(DbModelBuilder modelBuilder)
        {
            //aktif alanı turu olanları getirir. bu işleme soft delete denir
            modelBuilder.Entity<Urun>().
              Map(map => map.Requires("aktif")
              .HasValue(true)).Ignore(m=> m.aktif);
        }

        private void cokaCokİliski(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogrenci>().HasMany(o => o.ogretmenler)
            .WithMany(o => o.ogrenciler).Map(map =>
            {
                map.ToTable("OgrencilerOgretmenler").
                MapLeftKey("ogrenciid").MapRightKey("ogretmenid");
            });
        }

        private void calisanBirlestir(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calisan>().HasKey(c => c.calisanId).ToTable("Calisanlar");
            modelBuilder.Entity<calisanİletisimDetaylari>().HasKey(c => c.calisanId).ToTable("Calisanlar");
            modelBuilder.Entity<Calisan>().HasRequired(c => c.calisaniletisimdetaylari)
            .WithRequiredPrincipal(c => c.calisan);
        }

        private void kullaniciBol(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().Map(map => 
            {
                map.Properties(k => new
                {
                    k.kullaniciId,
                    k.ad,
                    k.sifre,
                });
                map.ToTable("kullaniciGiris");
            }).Map(map=> {
                map.Properties(d => new
                {
                    d.kullaniciId,
                    d.iletisim,
                    d.adres,
                });
                map.ToTable("kullaniciDiger");
            });
        }
    }
}
