using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_102190145_NguyễnQuýTriều
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetCBB();
            SetCBBSort();
        }
        public void SetCBB()
        {
            CCBCS.Items.Add(new CoSo { MaCS = "0", TenCoSo = "ALL", SLGV = 10 });
            foreach (CoSo cs in CSDL_OOP.Instance.GetAllCoSo())
            {
                CCBCS.Items.Add(cs);
            }
            CCBCS.SelectedIndex = 0;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm f = new DetailForm();
            f.SetGUIADD(CSDL_OOP.Instance.GetMaxMaGV());
            f.Del1 += new DetailForm.DelLoad(TuLoad);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection list = dataGridView1.SelectedRows;
            if (list.Count > 0)
            {
                DetailForm f = new DetailForm();
                f.DelEdit((int)list[0].Cells["MaGV"].Value);
                f.Del1 += new DetailForm.DelLoad(TuLoad);
                f.Show();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection list = dataGridView1.SelectedRows;
            foreach (DataGridViewRow dr in list)
            {
                int soLuong = CSDL_OOP.Instance.GetSLGVByMaCS(dr.Cells["MaCS"].Value.ToString());
                if (soLuong == 1)
                {
                    MessageBox.Show("Không thể xóa vì nếu xóa thì ko còn GV nào trong cơ sở");
                    return;
                }
                CSDL_OOP.Instance.DeleteGVByMaGV((int)dr.Cells["MaGV"].Value);
            }
            dataGridView1.DataSource = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
        }
        public void SetCBBSort()
        {
            CBBSortCBB.Items.AddRange(new CBBSort[]
                {
                new CBBSort{MaSort = 1 , SortTheo ="tuổi giảm"},
                new CBBSort{MaSort = 2 , SortTheo ="tuổi tăng"},
                new CBBSort{MaSort= 3, SortTheo ="Tên GV A-Z"},
                new CBBSort{MaSort= 4, SortTheo ="Tên GV Z-A"}
                });
        }
        private void TuLoad()
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
        }

        private void CBBSortCBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<GV> list = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
            switch (CBBSortCBB.SelectedIndex)
            {
                case 0:
                    CSDL_OOP.Instance.Sort(list, GV.ASCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 1:
                    CSDL_OOP.Instance.Sort(list, GV.DESCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 2:
                    CSDL_OOP.Instance.Sort(list, GV.ASCTenGV);
                    dataGridView1.DataSource = list;
                    break;
                case 3:
                    CSDL_OOP.Instance.Sort(list, GV.DESCTenGV);
                    dataGridView1.DataSource = list;
                    break;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<GV> list = CSDL_OOP.Instance.LoadData(((CoSo)CCBCS.SelectedItem).MaCS, txtSeach.Text);
            switch (CBBSortCBB.SelectedIndex)
            {
                case 0:
                    CSDL_OOP.Instance.Sort(list, GV.ASCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 1:
                    CSDL_OOP.Instance.Sort(list, GV.DESCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 2:
                    CSDL_OOP.Instance.Sort(list, GV.ASCTenGV);
                    dataGridView1.DataSource = list;
                    break;
                case 3:
                    CSDL_OOP.Instance.Sort(list, GV.DESCTenGV);
                    dataGridView1.DataSource = list;
                    break;
            }
        }
    }
}
