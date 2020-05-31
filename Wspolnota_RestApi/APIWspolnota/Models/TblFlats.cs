using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace APIWspolnota.Models
{
    public partial class TblFlats
    {
        public TblFlats()
        {
            TblInvoices = new HashSet<TblInvoices>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public Geometry Geometry { get; set; }
        public double SurfaceArea { get; set; }
        public string GeometryDesc { get; set; }
        public byte[] Map { get; set; }
        public int OwnerId { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public bool? Active { get; set; }

        [JsonIgnore]
        public virtual TblOwners Owner { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblInvoices> TblInvoices { get; set; }
    }
}
