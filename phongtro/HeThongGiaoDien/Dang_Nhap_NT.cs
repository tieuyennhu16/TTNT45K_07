using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;

namespace phongtro.HeThongGiaoDien
{
    public partial class Dang_Nhap_NT : Form
    {
        DangNhapDTO dn = new DangNhapDTO();
        public Dang_Nhap_NT()
        {
            InitializeComponent();
        }

        public bool BatLoi()
        {
                if (txttendangnhap.Text == "")
                {
                    MessageBox.Show("Không được phép bỏ trống tên đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txttendangnhap.Focus();
                    return false;
                }
                else if (txtmatkhau.Text == "")
                {
                    MessageBox.Show("Không được phép bỏ trống mật khẩu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtmatkhau.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
        }
        private void btdangnhap_Click(object sender, EventArgs e)
        {
            if (BatLoi() == true)
            {
                if (rbchunha.Checked == true)
                {
                    dn.SMaND = txttendangnhap.Text;
                    dn.SMatKhau = txtmatkhau.Text;
                    if (DangNhapDAO.Kiemtranguoidung(dn) == true)
                    {
                        frm_Main a = new frm_Main();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbnguoithan.Checked == true)
                {
                    dn.SMaNN = txttendangnhap.Text;
                    dn.SMK = txtmatkhau.Text;
                    if (DangNhapDAO.Kiemtranguothan(dn) == true)
                    {
                        NguoiNha a = new NguoiNha();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Dang_Nhap_NT_Load(object sender, EventArgs e)
        {
          
        }
    }
}
