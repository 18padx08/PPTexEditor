using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTexEditor.PPTexClasses
{
    public class Symbol
    {
        public string symbol { get; set; }
        public string value { get; set; }
        public string uncert { get; set; }

        public override string ToString()
        {
            return "{" + String.Format("'sym':'{0}', 'val':{1}, 'indep':{2}, 'uncert':{3}", symbol, value, (uncert == "" ? "False" : "True"), uncert) + "}";
        }
    }
}
