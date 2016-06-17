using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchBaseConnector
{
    internal static class AppSettings
    {
        public static string DefaultBucket
        {
            get { return "default"; }
        }

        public static string BeerBucket
        {
            get { return "mTravelCredit"; }
        }

    }
}
