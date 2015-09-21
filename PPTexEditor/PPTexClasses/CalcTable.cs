using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTexEditor.PPTexClasses
{
    public class CalcTable
    {
        public List<string> xheader { get; set; }
        public List<string> yheader { get; set; }
        public bool extended { get; set; }
        public List<List<string>> table { get; set; }
        public string description { get; set; }
        public List<Figure> figures { get; set; }

        public override string ToString()
        {
            var xheaderstring = "["+ String.Join(",", from xh in xheader select "'" + xh + "'") + "]";
            var yheaderstring = "[" + String.Join(",", from yh in yheader select "'" + yh + "'") + "]";
            var tablestring = "[" + String.Join(",", from rowcell in table select "[" + String.Join(",", from r in rowcell select "'" + r + "'") + "]") + "]";
            var figurestring = "[" + String.Join(",", from fig in figures select fig.ToString()) + "]";

            return "{% calcTable {" + String.Format("'xheader' : {0}, 'yheader' : {1}, 'extended' : {2}, 'table': {3}, 'desc' : '{4}', 'figure' : {5}",xheaderstring, yheaderstring, extended?"True":"False", tablestring, description, figurestring) + "}%}";
        }
    }
}
