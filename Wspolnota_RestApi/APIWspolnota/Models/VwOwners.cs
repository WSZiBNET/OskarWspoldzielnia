using System;
using System.Collections.Generic;

namespace APIWspolnota.Models
{
    public partial class VwOwners
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool OwnerActive { get; set; }
        public bool UserActive { get; set; }
    }
}
