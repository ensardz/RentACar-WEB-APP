using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class Iznajmljeno
    {
        public int IznajmljenoId { get; set; }
        public int VoziloId { get; set; }
        public string Pocetak { get; set; }
        public string Kraj { get; set; }
        public string Brojvozacke { get; set; }

        public virtual Korisnik BrojvozackeNavigation { get; set; }
        public virtual Vozilo Vozilo { get; set; }
    }
}
