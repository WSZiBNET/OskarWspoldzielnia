using System;
using System.Collections.Generic;

namespace APIWspolnota.Models
{
    public partial class VwFlats
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Geometry { get; set; }
        public double SurfaceArea { get; set; }
        public byte[] Map { get; set; }
        public int OwnerId { get; set; }
    }
}
