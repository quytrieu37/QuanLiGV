using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190145_NguyễnQuýTriều
{
    class CoSo
    {
        public string MaCS { get; set; }
        public string TenCoSo { get; set; }
        public int SLGV { get; set; }
        public override string ToString()
        {
            return MaCS + ", " + TenCoSo;
        }
    }
}
