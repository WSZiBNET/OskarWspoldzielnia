using System;
using System.Collections.Generic;

namespace APIWspolnota.Models
{
    public partial class TblUsers
    {
        public TblUsers()
        {
            TblOwners = new HashSet<TblOwners>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime AddDate { get; set; }
        public string AddUser { get; set; }
        public DateTime? ModDate { get; set; }
        public string ModUser { get; set; }
        public bool IsAdmin { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<TblOwners> TblOwners { get; set; }
    }
}
