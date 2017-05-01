using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public static class PharmacyExtentions
    {
        public static bool ContainsIgnoreCase(this string currentStr, string containedStr)
        {
            return currentStr.IndexOf(containedStr, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
