using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using NUnit.Framework;

namespace HoganLovells.Nbi 
{
    public static class Verify
    {
        private static StringBuilder errorMessages = new StringBuilder();
                

        public static StringBuilder ErrorMessages
        {
            get
            {
                StringBuilder value = errorMessages;
                errorMessages = new StringBuilder();
                return value;
            }
        }
        
        


        public static void AssertIsTrue(bool result)
        {
            Containers.LogStep logStep = new Containers.LogStep();

            StackTrace stackTrace = new StackTrace();
            string callingMethod = stackTrace.GetFrame(1).GetMethod().Name;
            try
            {
                logStep.Source = String.Concat(callingMethod, ".", "AssertIsTrue");
                logStep.Action = "Assert";
                logStep.Friendly = String.Concat("Assert that \"", result.ToString(), "\" is true");

                Assert.IsTrue(result);
                //Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                errorMessages.Append(callingMethod).Append("\r\n").Append(e.Message.ToString()).Append("\r\n\r\n");
                logStep.Friendly = e.Message.ToString();
                Reporting.LogStep(logStep);
            }
        }

        public static void AssertAreEqual(object expected, object actual)
        {
            Containers.LogStep logStep = new Containers.LogStep();

            StackTrace stackTrace = new StackTrace();
            string callingMethod = stackTrace.GetFrame(1).GetMethod().Name;
            try
            {
                logStep.Source = String.Concat(callingMethod, ".",  "AssertIsEqual");
                logStep.Action = "Assert";
                logStep.Friendly = String.Concat("Assert that \"", expected.ToString(), "\" is the same as \"", actual.ToString(), "\"");

                Assert.AreEqual(expected, actual);
                Reporting.LogStep(logStep);
            }
            catch (Exception e)
            {
                errorMessages.Append(callingMethod).Append("\r\n").Append(e.Message.ToString()).Append("\r\n\r\n");
                logStep.Friendly = e.Message.ToString();
                Reporting.LogStep(logStep);
            }

        }


    }
}
