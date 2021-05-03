namespace CodeFirst.Models
{
    public class calisanİletisimDetaylari
    {
        public int calisanId { get; set; }
        public string mail { get; set; }
        public string telefon { get; set; }
        public Calisan calisan { get; set; }
    }
}