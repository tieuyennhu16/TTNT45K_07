using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;


namespace phongtro.GUI
{
    /// <summary>
    /// Điền vào hết 3 bảng mới được
    /// Bảng PHONGTRO
    /// Bảng QUANLITHUEPHONG
    /// Bảng KHACHTRO
    /// </summary>
    public partial class frm_PhieuTraPhong : UserControl
    {
        TraPhongDTO_HHH tphong = new TraPhongDTO_HHH();
        DataTable dt_gridview;


        public frm_PhieuTraPhong()
        {
            InitializeComponent();
        }

        //Cho hiển thị duy nhất chủ nhà để tiện cho việc tính toán và thâu tiền...
        public void Load_combobox1()
        {
            try
            {
                DataTable dt;
                dt = TraPhongDAO_HHH.Load_Combobox();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "TenPhong";
                comboBox1.ValueMember = "MaPT";
            }
            catch
            {
                MessageBox.Show("Tất cả phòng đều trống.\nKhông có khách nào đễ trả phòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Cho hiển thị tất cả các thành viên của phòng...
        public void Load_DataGridview()
        {
            try
            {
                tphong.sMaPT = comboBox1.SelectedValue.ToString();
                dt_gridview = TraPhongDAO_HHH.Load_Datagridview(tphong);
                dataGridView1.DataSource = dt_gridview;
            }
            catch
            {
 
            }
            
        }
        private void frm_PhieuTraPhong_Load(object sender, EventArgs e)
        {
            Load_combobox1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_ma_phong.DataBindings.Add("text", comboBox1.DataSource, "MaPT");

                txt_ma_khach.DataBindings.Add("text", comboBox1.DataSource, "MaKT");

                txt_ten_nguoi_thue.DataBindings.Add("text", comboBox1.DataSource, "HoTen");
                txt_so_luong_toi_da.DataBindings.Add("text", comboBox1.DataSource, "SLToiDa");
                //----------------------------------------------

                txt_so_nguoi_hien_tai.DataBindings.Add("text", comboBox1.DataSource, "SoNguoiHienTai");
                //--------------------------------------------

                txt_CMND.DataBindings.Add("text", comboBox1.DataSource, "CMND");

                txt_ten_phong.DataBindings.Add("text", comboBox1.DataSource, "TenPhong");

                txt_nghe_nghiep.DataBindings.Add("text", comboBox1.DataSource, "NgeNghiep");

                txt_noi_sinh.DataBindings.Add("text", comboBox1.DataSource, "DiaChi");
               

                //--------------------------------------------

            }
            catch
            {

            }


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Load_DataGridview();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Xác nhận trả phòng??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                tphong.sMaKT = txt_ma_khach.Text;
                tphong.sMaPT = txt_ma_phong.Text;
                tphong.sTenKT = txt_ten_nguoi_thue.Text;
                string sCat = (dateTimePicker1.Text).Substring(3, 2) + "-" + (dateTimePicker1.Text).Substring(0, 2) + "-" + (dateTimePicker1.Text).Substring(6, 4);
                tphong.sNgayTra = sCat.ToString();
                tphong.sGhiChu = txt_ghi_chu.Text;

                if (TraPhongDAO_HHH.KiemTraTrung(tphong)== true)
                {
                    if (TraPhongDAO_HHH.Update_Trang_Thai_False_PHONGTRO(tphong) && TraPhongDAO_HHH.Update_Tat_Ca_Phong_False(tphong)&&TraPhongDAO_HHH.Update_ChuNha_False(tphong))
                    {
                        MessageBox.Show("Trả phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_combobox1();
                    }
                }
                else if (TraPhongDAO_HHH.Them(tphong) == true && TraPhongDAO_HHH.Update_Trang_Thai_False_PHONGTRO(tphong) && TraPhongDAO_HHH.Update_Tat_Ca_Phong_False(tphong) && TraPhongDAO_HHH.Update_ChuNha_False(tphong))
                {
                    MessageBox.Show("Trả phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_combobox1();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi trả phòng.\nXin vui lòng kiểm tra lại thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Load_combobox1();
                }
            }
        }

        private void txt_ghi_chu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}