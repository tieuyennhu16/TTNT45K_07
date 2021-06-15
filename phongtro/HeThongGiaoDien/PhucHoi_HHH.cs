using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongGiaoDien;
using phongtro.HeThongXuLy;

namespace phongtro.HeThongGiaoDien
{
    public partial class PhucHoi_HHH : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        PhucHoiDTO_HHH phuchoi = new PhucHoiDTO_HHH();
        
        public PhucHoi_HHH()
        {
            InitializeComponent();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            open.Filter = "|*.bak";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txt_link_phuc_hoi.Text = open.FileName;
                textBox2.Text = open.SafeFileName;
            }
            if (txt_link_phuc_hoi.Text != "")
            {
                btn_phuc_hoi.Enabled = true;
            }
        }

        private void btn_phuc_hoi_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            try
            {
                SaoLuu_HHH a = new SaoLuu_HHH();
                a.tudongtaobansaoluu();
            }
            catch
            {
            }
            try
            {
                
                DialogResult dl = MessageBox.Show("Thao tác này sẽ xóa toàn bộ dữ liệu và ghi đè lên dữ liệu cũ? \nBạn có muốn thực hiện không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dl == DialogResult.Yes)
                {
                    try
                    {

                        //887, 421
                        phuchoi.SPhucHoi = txt_link_phuc_hoi.Text;
                        PhucHoiDAO_HHH.phuchoi_cuc_bo(phuchoi);
                        PhucHoi_HHH.ActiveForm.Close();
                        MessageBox.Show("Phục hồi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Phục hồi không thành công..", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    PhucHoi_HHH.ActiveForm.Close();
                }
            }
            catch
            {
                MessageBox.Show("Phục hồi thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhucHoi_HHH_Load(object sender, EventArgs e)
        {
            btn_phuc_hoi.Enabled = false;
            pictureBox1.Visible = false;
        }
    }
}
