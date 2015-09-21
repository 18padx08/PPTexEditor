using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTexEditor.PPTexClasses
{
    public class Figure
    {
        public int xrow { get; set; }
        public int yrow { get; set; }
        public string title { get; set; }
        public string desc { get; set; }
        public string ylabel { get; set; }
        public string xlabel { get; set; }
        public string reference { get; set; }
        public string caption { get; set; }

        public override string ToString()
        {
            return "{" + String.Format("'xrow' : {0}, 'yrow' : {1}, 'title' : '{2}', 'desc' : '{3}', 'ylabel' : '{4}', 'xlabel' : '{5}', 'ref' : '{6}', 'caption' : '{7}'", xrow, yrow, title, desc, ylabel, xlabel, reference, caption) + "}";
        }
    }
}
