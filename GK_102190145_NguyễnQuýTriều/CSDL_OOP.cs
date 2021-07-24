using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190145_NguyễnQuýTriều
{
    class CSDL_OOP
    {
        public delegate bool DelSort(object a, object b);
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        public bool IsTrue(int MaGV)
        {
            foreach(DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if((int)dr["MaGV"] == MaGV)
                {
                    return true;
                }    
            }
            return false;
        }
        public GV ConvertToGV(DataRow dr)
        {
            GV gv = new GV();
            gv.MaGV = (int)dr["MaGV"];
            gv.Ten = dr["Ten"].ToString();
            gv.SDT = dr["SDT"].ToString();
            gv.NS = (DateTime)dr["NS"];
            gv.MaCS = dr["MaCS"].ToString();
            return gv;
        }
        public List<GV> GetAllGV()
        {
            List<GV> list = new List<GV>();
            foreach(DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                list.Add(ConvertToGV(dr));
            }
            return list;
        }
        public GV GetGVByMaGV(int maGV)
        {
            GV gv = null;
            foreach(DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if ((int)dr["MaGV"] == maGV)
                {
                    gv = ConvertToGV(dr);
                    break;
                }
            }
            return gv;
        }
        public List<CoSo> GetAllCoSo()
        {
            List<CoSo> list = new List<CoSo>();
            foreach(DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                CoSo cs = new CoSo();
                cs.MaCS = dr["MaCS"].ToString();
                cs.TenCoSo = dr["TenCoSo"].ToString();
                cs.SLGV = (int)dr["SLGV"];
                list.Add(cs);
            }
            return list;
        }
        public bool DeleteGVByMaGV(int MaGV)
        {
            if(!CSDL.Instance.DeleteDataRowGV(MaGV))
            {
                return false;
            }
            return true;
        }
        public bool AddOrEditGV(GV gv)
        {
            if(!IsTrue(gv.MaGV))
            {
                if(GetSLGVByMaCS(gv.MaCS) >= GetCoSoByMaCS(gv.MaCS).SLGV)
                {
                    return false;
                }
                CSDL.Instance.AddDatarowGV(gv);
                return true;
            }
            else
            {
                CSDL.Instance.EditDataRowGV(gv);
                return true;
            }
        }
        public List<GV> LoadData(string MaCS, string textSeach)
        {
            if (textSeach == "")
            {
                if (MaCS == "0")
                {
                    return CSDL_OOP.Instance.GetAllGV();
                }
                else
                {
                    return CSDL_OOP.Instance.GetListGVByMaCS(MaCS);
                }
            }
            else
            {
                List<GV> list = new List<GV>();
                if (MaCS == "0")
                {
                    foreach (GV gv in CSDL_OOP.Instance.GetAllGV())
                    {
                        if (gv.Ten.ToLower().Contains(textSeach.ToLower()))
                        {
                            list.Add(gv);
                        }
                    }
                }
                else
                {
                    foreach (GV gv in CSDL_OOP.Instance.GetListGVByMaCS(MaCS))
                    {
                        if (gv.Ten.ToLower().Contains(textSeach.ToLower()))
                        {
                            list.Add(gv);
                        }
                    }
                }
                return list;
            }
        }
        public List<GV> GetListGVByMaCS(string maCS)
        {
            List<GV> list = new List<GV>();
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if (dr["MaCS"].ToString() == maCS)
                {
                    list.Add(ConvertToGV(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// lấy idGV cao nhất hiện tại dùng để add
        /// </summary>
        /// <returns></returns>
        public int GetMaxMaGV()
        {
            int max = 0;
            foreach(GV gv in GetAllGV())
            {
                if(gv.MaGV >= max)
                {
                    max = gv.MaGV;
                }    
            }
            return max;
        }
        public void Sort(List<GV> list, DelSort del)
        {
            GV temp;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (del(list[i], list[j]))
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
        public int GetSLGVByMaCS(string maCS)
        {
            int dem=0;
            foreach(GV dv in GetListGVByMaCS(maCS))
            {
                ++dem;
            }
            return dem;
        }
        public CoSo GetCoSoByMaCS(string maCS)
        {
            CoSo cs = new CoSo();
            foreach (DataRow dr in CSDL.Instance.DTCS.Rows)
            {
                if (dr["MaCS"].ToString() == maCS)
                {
                    cs.MaCS = dr["MaCS"].ToString();
                    cs.TenCoSo = dr["TenCoSo"].ToString();
                    cs.SLGV = (int)dr["SLGV"];
                    break;
                }
            }
            return cs;
        }
    }
}
