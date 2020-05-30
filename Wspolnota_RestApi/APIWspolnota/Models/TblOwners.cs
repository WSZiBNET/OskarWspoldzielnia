using System;
using System.Collections.Generic;

namespace APIWspolnota.Models
{
    public partial class TblOwners
    {
        public TblOwners()
        {
            TblFlats = new HashSet<TblFlats>();
            TblInvoices = new HashSet<TblInvoices>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public bool? Active { get; set; }

        public virtual TblUsers User { get; set; }
        public virtual ICollection<TblFlats> TblFlats { get; set; }
        public virtual ICollection<TblInvoices> TblInvoices { get; set; }
    }
}
