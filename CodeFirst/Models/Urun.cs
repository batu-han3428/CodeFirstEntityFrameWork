using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    [Table("Urunler")]
    public class Urun
    {
        [Key]
        public int urunId { get; set; }
        [StringLength(50)]
        public string urunAd { get; set; }
        public decimal urunFiyat { get; set; }
        //soft delete
        public bool aktif { get; set; }
        //Nullable özelliği.  intin null değeri 0 olduğu için 0 stok girildiğinde hata
        //vermesin diye null alma özelliği verdik
        public int? urunStok { get; set; }
        //Navigation Property (bire çok ilişki)
        public int kategoriId { get; set; }
        public Kategori Kategoriler { get; set; }

    }
}
