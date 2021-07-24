using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190145_NguyễnQuýTriều
{
    class CBBSort
    {
        public int MaSort { get; set; }
        public string SortTheo { get; set; }
        public override string ToString()
        {
            return MaSort.ToString() + ", " + SortTheo;
        }
    }
}
