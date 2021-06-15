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
    public partial class Cap_Nhat_Trang_Thai_Thue_HHH : Form
    {
        TrangThaiThueDTO_HHH tt = new TrangThaiThueDTO_HHH();
        
        public Cap_Nhat_Trang_Thai_Thue_HHH()
        {
            InitializeComponent();
        }
        public string makhachtro { get; set; }
        public string Maphong { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
        public string nghenghiep { get; set; }
        public string sdt { get; set; }

        private void Cap_Nhat_Trang_Thai_Thue_HHH_Load(object sender, EventArgs e)
        {
            txt_ma_khach.Text = makhachtro;
            txt_maphong.Text= Maphong;
            txt_hoten.Text = hoten;
            txt_dia_chi.Text = diachi;
            txt_nghe_nghiep.Text = nghenghiep;
            txt_sdt.Text = sdt;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dl = MessageBox.Show("Bạn có muốn cập nhật không??\nCảnh báo: Thao tác nhày không thể phục hồi.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.OK)
            {
                tt.SMaKT = txt_ma_khach.Text;
                tt.SMaPT = txt_maphong.Text;
                tt.sHoTen = txt_hoten.Text;
                tt.sDiaChi = txt_dia_chi.Text;
                tt.SNghenghiep = txt_nghe_nghiep.Text;
                tt.SDT = txt_sdt.Text;
                if (TrangThaiThueDAO_HHH.CapNhat(tt) == true)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cap_Nhat_Trang_Thai_Thue_HHH.ActiveForm.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cap_Nhat_Trang_Thai_Thue_HHH.ActiveForm.Close();
        }

    }
}
