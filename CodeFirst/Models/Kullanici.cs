using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Kullanici
    {
        public int kullaniciId { get; set; }
        public string ad { get; set; }
        public string sifre { get; set; }
        public string iletisim { get; set; }
        public string adres { get; set; }
    }
}
