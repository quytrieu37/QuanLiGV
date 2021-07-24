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
    public partial class DetailForm : Form
    {
        public delegate void Mydel(int maGV);
        public Mydel DelEdit;
        public delegate void DelLoad();
        public DelLoad Del1;
        public DetailForm()
        {
            InitializeComponent();
            SetCBB();
            DelEdit += new Mydel(SetGUIEdit);
        }
        public void SetCBB()
        {
            foreach (CoSo cs in CSDL_OOP.Instance.GetAllCoSo())
            {
                CBBCS.Items.Add(new CoSo
                {
                    MaCS = cs.MaCS,
                    SLGV = cs.SLGV,
                    TenCoSo = cs.TenCoSo
                });
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtName.Text == null || txtSDT== null || CBBCS.SelectedIndex == -1)
            {
                MessageBox.Show("vui lòng nhập đủ dữ liệu");
                return;
            }  
            else
            {
                if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Chiều dài số DT : 10");
                    return;
                }
                GV gv = new GV()
                {
                    MaGV = Convert.ToInt32(txtMGV.Text),
                    Ten = txtName.Text,
                    NS = dateTimePicker1.Value,
                    SDT = txtSDT.Text,
                    MaCS = ((CoSo)CBBCS.SelectedItem).MaCS
                };
                if (!CSDL_OOP.Instance.AddOrEditGV(gv))
                {
                    MessageBox.Show("Số lượng giáo viên đã vượt quá mức cho phép ko thể thêm");
                    return;
                }
                Del1();
                this.Dispose();
            }    
        }
        public void SetGUIADD(int ma)
        {
            txtMGV.Text = (++ma).ToString();
        }
        public void SetGUIEdit(int ma)
        {
            GV gv = CSDL_OOP.Instance.GetGVByMaGV(ma);
            txtMGV.Text = gv.MaGV.ToString();
            txtName.Text = gv.Ten;
            txtSDT.Text = gv.SDT;
            for (int i=0; i< CBBCS.Items.Count;i++)
            {
                if(((CoSo)CBBCS.Items[i]).MaCS == gv.MaCS)
                {
                    CBBCS.SelectedIndex = i;
                }    
            }    
            dateTimePicker1.Value = gv.NS;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
