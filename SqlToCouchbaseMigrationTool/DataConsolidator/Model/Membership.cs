using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConsolidator.Model
{
    public class Membership
    {
        public string Type { get; set; }

        public StatusType Status { get; set; }
    }

    public enum StatusType
    {
        Active = 0,
        Cancelled = 1,
        Expired = 2
    }
}
