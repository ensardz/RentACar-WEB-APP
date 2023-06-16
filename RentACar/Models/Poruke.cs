using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class Poruke
    {
        public int PorukaId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrVozacke { get; set; }
        public string Poruka { get; set; }
    }
}
