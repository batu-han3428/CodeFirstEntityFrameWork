using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
    public class Ogrenci
    {
        public int ogrenciId { get; set; }
        public string ad { get; set; }
        public List<Ogretmen> ogretmenler { get; set; }
    }
}
