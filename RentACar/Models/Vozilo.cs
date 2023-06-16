using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class Vozilo
    {
        public Vozilo()
        {
            Iznajmljenos = new HashSet<Iznajmljeno>();
        }

        public int VoziloId { get; set; }
        public string Proizvođač { get; set; }
        public string Model { get; set; }
        public string CijenaPoDanu { get; set; }
        public string Gorivo { get; set; }
        public string Mjenjač { get; set; }
        public string SnagaMotora { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string RegOznaka { get; set; }
        public string Slika { get; set; }

        public virtual ICollection<Iznajmljeno> Iznajmljenos { get; set; }
    }
}
