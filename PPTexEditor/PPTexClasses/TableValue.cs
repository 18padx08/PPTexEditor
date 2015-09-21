using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTexEditor.PPTexClasses
{
    public class TableValue
    {
        public int id { get; set; }
        public string value { get; set; }
        public bool isXheader { get; set; } = false;
        public bool isYheader { get; set; } = false;
        public int Row { get { return id / 8; } private set { } }
    }
}
