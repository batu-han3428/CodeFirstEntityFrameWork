using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string kategoriAd { get; set; }
        [StringLength(150)]
        public string kategoriAciklama { get; set; }

        public virtual List<Urun> urunler { get; set; }
            
       
    }
}
