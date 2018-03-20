using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoganLovells.Nbi
{
    public static partial class DataGenerator
    {
        public static class ClientDetails
        {
            public static string ClientType
            {
                get { return "Government"; }
            }

            public static string ClientName
            {
                get { return String.Concat("Client Name: ", DateTime.Now.ToString("yyMMdd HHmmss")); }
            }

            public static string ParentCompanyName
            {
                get { return String.Concat("Parent Name: ", DateTime.Now.ToString("yyMMdd HHmmss")); }
            }

            public static string IsAnyCompany
            {
                get { return "No/Unknown"; }
            }

            public static string ClientContactName
            {
                get { return String.Concat("Contact Name: ", DateTime.Now.ToString("yyMMdd HHmmss")); }
            }

            public static string StreetAddressLine1
            {
                get { return "122 Hello St"; }
            }

            public static string City
            {
                get { return "London"; }
            }

            public static string Country
            {
                get { return "United Kingdom"; }
            }

            public static string Province
            {
                get { return "London"; }
            }

        }

    }
}
