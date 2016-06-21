using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataConsolidator.Model
{
    public class RedemptionDetails
    {
        public string OrderId { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string ProductType { get; set; }

        public string VendorId { get; set; }

        public string VendorName { get; set; }
    }
}
