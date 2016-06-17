using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConsolidator.Model
{
    public class Owner
    {
        public string Username { get; set; }

        public AccountStatusType AccountStatus { get; set; }

        public string CountryOfResidence { get; set; }

        public List<Membership> Memberships { get; set; }
    }

    public enum AccountStatusType
    {
        Enabled = 0,
        Disabled = 1
    }
}
