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
        public ProductType Type { get; set; }

        public string ReferenceId { get; set; }

        public string VendorId { get; set; }
    }

    public enum ProductType
    {
        Air = 0,
        Car = 1,
        Hotel = 2,
        Activity = 3,
        Hideaway = 4
    }
}
