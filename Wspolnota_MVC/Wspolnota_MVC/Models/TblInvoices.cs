using System;
using System.Collections.Generic;

namespace APIWspolnota.Models
{
    public partial class TblInvoices
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Value { get; set; }
        public int OwnerId { get; set; }
        public int FlatId { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public bool? Active { get; set; }

        public virtual VwFlats Flat { get; set; }
        public virtual TblOwners Owner { get; set; }
    }
}
