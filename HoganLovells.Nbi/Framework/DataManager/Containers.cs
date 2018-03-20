using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoganLovells.Nbi 
{
    public class Containers { 

        public class LogStep
        {
            public string Source {get;set; }
            public string ElementName { get; set; }
            public string Action { get; set; }
            public string Data { get; set; }
            public string Friendly { get; set; }
            public string Screenshot { get; set; }

            private string result = "pass";

            public string Result
            {
                get { return result; }
                set { result = value; }
            }

        }
    }
}
