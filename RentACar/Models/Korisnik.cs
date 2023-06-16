using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Iznajmljenos = new HashSet<Iznajmljeno>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Brojvozacke { get; set; }
        public int Telefon { get; set; }
        public string Adresa { get; set; }

        public virtual ICollection<Iznajmljeno> Iznajmljenos { get; set; }
    }
}
