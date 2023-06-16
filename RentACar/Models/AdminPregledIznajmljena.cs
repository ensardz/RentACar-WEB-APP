using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class AdminPregledIznajmljena
    {
        public int VoziloId { get; set; }
        public string Brojvozacke { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Telefon { get; set; }
        public string Model { get; set; }
        public string CijenaPoDanu { get; set; }
        public string RegOznaka { get; set; }
        public int? BrojDana { get; set; }
    }
}
