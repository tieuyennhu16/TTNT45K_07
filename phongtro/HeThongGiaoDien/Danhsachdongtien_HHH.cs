using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;

using DevExpress.XtraEditors;

namespace phongtro.HeThongGiaoDien
{
    public partial class Danhsachdongtien_HHH : DevExpress.XtraEditors.XtraUserControl
    {
        ThuTienDTO_HHH tt = new ThuTienDTO_HHH();

        public Danhsachdongtien_HHH()
        {
            InitializeComponent();
        }


        public void Loaddulieu()
        {
            DataTable dt;
            dt = ThuTienDAO_HHH.XemDanhSachDaThu();
            gridControl1.DataSource = dt;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Thongke_HHH_Load(object sender, EventArgs e)
        {
            Loaddulieu();
        }

        private void Thongke_HHH_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sAddress = @"D:\CaoDangNgheTG";
            gridView1.ShowRibbonPrintPreview();
        }

        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                gridView1.ShowPrintPreview();
            }
        }
    }
}
