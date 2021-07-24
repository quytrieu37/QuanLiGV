using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190145_NguyễnQuýTriều
{
    class GV
    {
        public int MaGV { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public DateTime NS { get; set; }
        public string MaCS { get; set; }
        public static bool ASCTenGV(object a, object b)
        {
            if (String.Compare(((GV)a).Ten, ((GV)b).Ten) > 0)
            {
                return true;
            }
            return false;
        }
        public static bool DESCTenGV(object a, object b)
        {
            if (String.Compare(((GV)a).Ten, ((GV)b).Ten) < 0)
            {
                return true;
            }
            return false;
        }
        public static bool DESCNS(object a, object b)
        {
            if (((GV)a).NS < ((GV)b).NS)
            {
                return true;
            }
            return false;
        }
        public static bool ASCNS(object a, object b)
        {
            if (((GV)a).NS > ((GV)b).NS)
            {
                return true;
            }
            return false;
        }
    }
}
