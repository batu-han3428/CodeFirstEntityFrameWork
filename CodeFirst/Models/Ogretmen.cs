using System.Collections.Generic;

namespace CodeFirst.Models
{
    public class Ogretmen
    {
        public int ogretmenId { get; set; }
        public string ad { get; set; }
        public List<Ogrenci> ogrenciler { get; set; }
    }
}