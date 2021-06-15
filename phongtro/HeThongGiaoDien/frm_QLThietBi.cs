using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;
namespace phongtro.GUI
{
    public partial class frm_QLThietBi : UserControl
    {
        ThietBi_DTO_HHH tb = new ThietBi_DTO_HHH();
       
        public frm_QLThietBi()
        {
            InitializeComponent();
            //dateTimePicker1.CustomFormat = "dddd.MMMM.yyyy";
        }
        private void frm_QLThietBi_Load(object sender, EventArgs e)
        {
            Load_Datagridview();
            Load_Combobox();
            btn_Luu.Enabled = false;
        }
        //Load combobox
        public void Load_Combobox()
        {
            DataTable dt;
            dt = ThietBi_DAO_HHH.LayDanhSachPhong();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "TenPhong";
            comboBox1.ValueMember = "MaPT";
        }

        //Load datagridview
        public void Load_Datagridview()
        {
            DataTable dt;
            dt = ThietBi_DAO_HHH.LayDanhSachThietBi();
            dataGridView1.DataSource = dt;

            btn_Capnhat.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txtten.Clear();
            txt_so_luong.Clear();
            checkBox1.Checked = true;
            txt_gia.Clear();

            btn_Capnhat.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Them.Enabled = false;
            btn_Luu.Enabled = true;
        }

        public bool KiemTra()
        {
            
                if (txt_so_luong.Text == "")
                {
                    MessageBox.Show("Không được phép bỏ trống số lượng sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_so_luong.Focus();
                    return false;
                }
                if (txtten.Text == "")
                {
                    MessageBox.Show("Không được phép bỏ trống tên sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtten.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

            if (KiemTra() == true)
            {
                
                    tb.SMaPT = comboBox1.SelectedValue.ToString();
                    tb.STenTB = txtten.Text;
                    tb.SNhanHieu = cbx_nhan_hieu.Text;
                    tb.SSoLuong = Convert.ToInt32(txt_so_luong.Text);
                    if (checkBox1.Checked == true)
                    {
                        tb.STinhTrang = true;
                    }
                    else
                    {
                        tb.STinhTrang = false;
                    }
                    tb.SGia = txt_gia.Text;


                    string Cat = (dateTimePicker1.Text).Substring(3, 2) + "-" + (dateTimePicker1.Text).Substring(0, 2) + "-" + (dateTimePicker1.Text).Substring(6, 4);
                    tb.SNgaymua = Cat.ToString();

                   
                    if (ThietBi_DAO_HHH.Them(tb) == true)
                    {
                        MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_Datagridview();
                    }
                    else
                    {
                        MessageBox.Show("Lưu dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
          
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox1.DisplayMember = dataGridView1.SelectedRows[0].Cells["MaPT"].Value.ToString();

                txtten.Text = dataGridView1.SelectedRows[0].Cells["TenTB"].Value.ToString();
                cbx_nhan_hieu.Text = dataGridView1.SelectedRows[0].Cells["NhanHieu"].Value.ToString();
                
                txt_so_luong.Text = dataGridView1.SelectedRows[0].Cells["SoLuong"].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells["Tinhtrang"].Value.ToString() == "True")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells["NgayMua"].Value.ToString();
                txt_gia.Text = dataGridView1.SelectedRows[0].Cells["Gia"].Value.ToString();

            }
            catch
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Load_Combobox();
        }

        private void btn_Capnhat_Click(object sender, EventArgs e)
        {
            try
            {
                tb.SMaTB = dataGridView1.SelectedRows[0].Cells["MaTB"].Value.ToString();
                tb.SMaPT = comboBox1.SelectedValue.ToString();
                tb.STenTB = txtten.Text;
                tb.SNhanHieu = cbx_nhan_hieu.Text;
                tb.SSoLuong = Convert.ToInt32(txt_so_luong.Text);

                if (checkBox1.Checked == true)
                {
                    tb.STinhTrang = true;
                }
                else
                {
                    tb.STinhTrang = false;
                }

                tb.SGia = txt_gia.Text;
                string Cat = (dateTimePicker1.Text).Substring(3, 2) + "-" + (dateTimePicker1.Text).Substring(0, 2) + "-" + (dateTimePicker1.Text).Substring(6, 4);
                tb.SNgaymua = Cat.ToString();

                if (ThietBi_DAO_HHH.CapNhat(tb) == true)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Datagridview();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Gợi ý: Chọn 1 dòng trên Datagridview \nĐiền thông tin cần cập nhật vào textbox rồi nhấn nút Cập Nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
           

            DialogResult dl = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                try
                {
                    int n = dataGridView1.SelectedRows.Count;
                    for (int i = n - 1; i >= 0; i--)
                    {
                        tb.SMaTB = dataGridView1.SelectedRows[i].Cells["matb"].Value.ToString();
                        ThietBi_DAO_HHH.Xoa(tb);
                    }
                    Load_Datagridview();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Gợi ý: Bạn có thể xóa cùng lúc nhiều thiết bị bằng cú pháp sau:.\nB1: Chọn nhiều dòng.\nB2: Nhấn chuột phải.\nB3: Chọn lệnh xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Load_Datagridview();
                }
                
            }
            else
            {
                MessageBox.Show("Đã hủy lệnh xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void cậpNhậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btn_Capnhat.PerformClick();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Xoa.PerformClick();
        }
    }
}
