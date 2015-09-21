using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTexEditor.PPTexClasses
{
    public class Evaltex
    {
        public string function { get; set; }
        public string fname { get; set; }
        public List<Symbol> symbols { get; set; }
        public bool errors { get; set; }
        public int digits { get; set; }
        public string units { get; set; }

        public override string ToString()
        {
            var uncertString = String.Join(",",(from s in symbols
                                select s.ToString()).ToList<string>());
            return "{%evaltex {"  + String.Format("'function':'{0}', 'fname':'{1}', 'symbols' : [{2}], 'errors':{3}, 'digits':{4}, 'units':'{5}'", function,fname,uncertString, errors? "True": "False",digits, units) + "} %}";
        }
    }
}
