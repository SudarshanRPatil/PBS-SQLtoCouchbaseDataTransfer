using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConsolidator.Model
{
    public class Owner
    {
        public string Username { get; set; }

        public string AccountStatus { get; set; }

        public string CountryOfResidence { get; set; }

        public List<Membership> Memberships { get; set; }
    }
}
