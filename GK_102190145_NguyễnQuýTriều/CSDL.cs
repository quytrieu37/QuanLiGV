using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_102190145_NguyễnQuýTriều
{
    class CSDL
    {
        public DataTable DTCS { get; set; }
        public DataTable DTGV { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {

            }
        }

        private static CSDL _Instance;
        private CSDL()
        {
            DTGV = new DataTable();
            DTGV.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("MaGV", typeof(int)),
                    new DataColumn("Ten"),
                    new DataColumn("SDT"),
                    new DataColumn("NS", typeof(DateTime)),
                    new DataColumn("MaCS")
                });
            DataRow dr = DTGV.NewRow();
            dr["MaGV"] = 1; dr["Ten"] = "NVA"; dr["SDT"] = "0123456789";
            dr["NS"] = DateTime.Now; dr["MaCS"] = "CS001";
            DTGV.Rows.Add(dr);

            DataRow dr1 = DTGV.NewRow();
            dr1["MaGV"] = 2; dr1["Ten"] = "NVB"; dr1["SDT"] = "0123782738";
            dr1["NS"] = DateTime.Now; dr1["MaCS"] = "CS002";
            DTGV.Rows.Add(dr1);

            DataRow dr2 = DTGV.NewRow();
            dr2["MaGV"] = 3; dr2["Ten"] = "NVC"; dr2["SDT"] = "0136276372";
            dr2["NS"] = DateTime.Now; dr2["MaCS"] = "CS002";
            DTGV.Rows.Add(dr2);

            DataRow dr3 = DTGV.NewRow();
            dr3["MaGV"] = 4; dr3["Ten"] = "NVD"; dr3["SDT"] = "0126326362";
            dr3["NS"] = DateTime.Now; dr3["MaCS"] = "CS001";
            DTGV.Rows.Add(dr3);


            DTCS = new DataTable();
            DTCS.Columns.AddRange(new DataColumn[] {
                new DataColumn("MaCS"),
                new DataColumn("TenCoSo"),
                new DataColumn("SLGV", typeof(int))
            });
            DataRow dr21 = DTCS.NewRow();
            dr21["MaCS"] = "CS001";
            dr21["TenCoSo"] = "Chi nhánh 1";
            dr21["SLGV"] = 3;

            DTCS.Rows.Add(dr21);
            DataRow dr22 = DTCS.NewRow();
            dr22["MaCS"] = "CS002";
            dr22["TenCoSo"] = "Chi nhánh 2";
            dr22["SLGV"] = 20;
            DTCS.Rows.Add(dr22);
        }
        public void AddDatarowGV(GV gv)
        {
            DataRow dr = CSDL.Instance.DTGV.NewRow();
            dr["MaGV"] = gv.MaGV; dr["Ten"] = gv.Ten; dr["SDT"] = gv.SDT;
            dr["NS"] = gv.NS; dr["MaCS"] = gv.MaCS;
            CSDL.Instance.DTGV.Rows.Add(dr);
        }
        public void EditDataRowGV(GV gv)
        {
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if ((int)dr["MaGV"] == gv.MaGV)
                {
                    dr["Ten"] = gv.Ten; dr["SDT"] = gv.SDT;
                    dr["NS"] = gv.NS; dr["MaCS"] = gv.MaCS;
                }
            }
        }
        public bool DeleteDataRowGV(int MaGV)
        {
            foreach (DataRow dr in CSDL.Instance.DTGV.Rows)
            {
                if ((int)dr["MaGV"] == MaGV)
                {
                    CSDL.Instance.DTGV.Rows.Remove(dr);
                    return true;
                }
            }
            return false;
        }
    }
}
