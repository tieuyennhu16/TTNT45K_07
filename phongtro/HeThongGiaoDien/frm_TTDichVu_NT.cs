using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;
using System.Data.SqlClient;

namespace phongtro.GUI
{
    public partial class frm_TTDichVu : UserControl
    {
        ThongtindichvuDTO dv = new ThongtindichvuDTO();

        public frm_TTDichVu()
        {
            InitializeComponent();
        }

        private void frm_TTDichVu_Load(object sender, EventArgs e)
        {
            load_dgv();
            btn_Luu.Enabled = false;
        }
        public void load_dgv()
        {
            DataTable dt;
            dt = ThongtindichvuDAO.dodgv();
            dgv.DataSource = dt;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Capnhat.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            txttendv.Clear();
            txtgia.Clear();
            txtdonvitinh.Clear();

        }

        private void btn_Capnhat_Click(object sender, EventArgs e)
        {
            dv.SMaDV = dgv.SelectedRows[0].Cells["MaDV"].Value.ToString();
            dv.STenDV = txttendv.Text;
            dv.SDonGia = Convert.ToInt32(txtgia.Text);
            dv.SDonViTinh = txtdonvitinh.Text;

            if (ThongtindichvuDAO.CapNhat(dv) == true)
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_dgv();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load_dgv();
            }
        }
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txttendv.Text = dgv.SelectedRows[0].Cells["TenDV"].Value.ToString();
                txtgia.Text = dgv.SelectedRows[0].Cells["DonGia"].Value.ToString();
                txtdonvitinh.Text = dgv.SelectedRows[0].Cells["DonViTinh"].Value.ToString();
            }
            catch
            {

            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Capnhat.Enabled = true;
            dv.STenDV = txttendv.Text;
            dv.SDonGia = Convert.ToInt32(txtgia.Text);
            dv.SDonViTinh = txtdonvitinh.Text;

            if (ThongtindichvuDAO .Them (dv) == true)
            {
                MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_dgv();
            }
            else
            {

                MessageBox.Show("Ghi không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                load_dgv();
            }

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                try
                {
                    dv.SMaDV = dgv.SelectedRows[0].Cells["MaDV"].Value.ToString();
                    if (dgv.SelectedRows[0].Cells["MaDV"].Value.ToString() == "1" || dgv.SelectedRows[0].Cells["MaDV"].Value.ToString() == "2" || dgv.SelectedRows[0].Cells["MaDV"].Value.ToString() == "3")
                    {
                        MessageBox.Show("Xóa không thành công do chứa bảng khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if ((dgv.SelectedRows[0].Cells["MaDV"].Value.ToString()!= "1" || dgv.SelectedRows[0].Cells["MaDV"].Value.ToString() != "2" || dgv.SelectedRows[0].Cells["MaDV"].Value.ToString() != "3"))
                    {
                        if (ThongtindichvuDAO.Xoa(dv) == true)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load_dgv();
                        }
                        else if (ThongtindichvuDAO.Xoa(dv) == false)
                        {
                            MessageBox.Show("Xóa không thành công do chứa bảng khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                    
                }
              
            else
            {
                MessageBox.Show("Đã hủy lệnh xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            load_dgv();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}