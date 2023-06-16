using System;
using System.Collections.Generic;

#nullable disable

namespace RentACar.Models
{
    public partial class IznamljenaVozila
    {
        public int IznajmljenoId { get; set; }
        public int VoziloId { get; set; }
        public string Model { get; set; }
        public string CijenaPoDanu { get; set; }
        public string RegOznaka { get; set; }
        public string Slika { get; set; }
        public string Pocetak { get; set; }
        public string Kraj { get; set; }
        public int? BrojDana { get; set; }
    }
}
