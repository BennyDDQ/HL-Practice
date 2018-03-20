using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoganLovells.Nbi
{
    public static partial class DataGenerator
    {
        public static class MatterDetails
        { 
            public static string Name
            {
                get { return "Matter" + DateTime.Now.ToString("yyyyMMdd HHmmss"); }
            }

            public static string Description 
            {
                get { return "Matter Description" + DateTime.Now.ToString("yyyyMMdd HHmmss"); }
            }


            public static string MatterPracticeArea
            {
                get { return "Corp: Capital Markets"; }
            }

            public static string MatterWorkType
            {
                get { return "8001 IPO"; }
            }

            public static string MatterIndustryType
            {
                get { return "Automotive"; }
            }

            public static string PleaseExplain
            {
                get { return "Please Explain: " + DateTime.Now.ToString("yyyyMMdd HHmmss"); }
            }

            public static string MatterFeeArranagementType
            {
                get { return "Hourly"; }
            }

            public static string DescribeArrangement
            {
                get { return "Describe Arrangement: " + DateTime.Now.ToString("yyyyMMdd HHmmss"); }
            }

            public static string MatterCurrency
            {
                get { return "USD - US Dollar"; }
            }


        }
    }
}
