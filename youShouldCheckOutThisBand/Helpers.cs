using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand
{
    public static class Helpers
    {
        public static string GetIdFromUri(string uri)
        {
            return uri.Split(':')[2];
        }
    }
}
