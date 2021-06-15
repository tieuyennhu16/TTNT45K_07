using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.FileKetNoiCSDL;
using phongtro.HeThongXuLy;
using phongtro.GUI;
using DevExpress.XtraEditors;

namespace phongtro.HeThongGiaoDien
{
    public partial class TinhTienTro_HHH : DevExpress.XtraEditors.XtraUserControl
    {
        ThuTienDTO_HHH tt = new ThuTienDTO_HHH();
        public TinhTienTro_HHH()
        {
            InitializeComponent();
        }

        //Cho hiển thị duy nhất chủ nhà để tiện cho việc tính toán và thâu tiền...
        public void Load_combobox1()
        {
            try
            {
                DataTable dt;
                dt = ThuTienDAO_HHH.Load_Combobox();
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "TenPhong";
                comboBox1.ValueMember = "MaPT";
            }
            catch
            {
                MessageBox.Show("Tất cả phòng đều trống.\nKhông có khách nào đễ trả phòng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Load_DataGridview()
        {
            try
            {
                tt.sMaPT = comboBox1.SelectedValue.ToString();
                DataTable dt;
                dt = ThuTienDAO_HHH.Load_Datagridview(tt);
                datagridview1.DataSource = dt;
            }
            catch
            {

            }

        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                Thoigiandongtiengannhat();

                Tinhsongay();

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

                date_ngay_thue.DataBindings.Add("text", comboBox1.DataSource, "NgayThue");

                Datetime_ngay_dong_gan_nhat.DataBindings.Add("text", comboBox1.DataSource, "NgayThu");

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
        private void TinhTienTro_HHH_Load(object sender, EventArgs e)
        {
            Load_combobox1();
            Thoigiandongtiengannhat();
            txt_so_ki_dien.Enabled = false;
            txt_so_khoi_nuoc.Enabled = false;
            btn_tinhtien.Enabled = false;
        }
        //TÍNH TIỀN DỊCH VỤ...
        public bool BatLoi()
        {
            string sCat = (date_ngay_thu.Text).Substring(3, 2) + "-" + (date_ngay_thu.Text).Substring(0, 2) + "-" + (date_ngay_thu.Text).Substring(6, 4);
            tt.sNgayThu = sCat.ToString();
            tt.sMaKT = txt_ma_khach.Text;

            if (checkBox1.Checked == true || checkBox2.Checked == true)
            {
                if (txt_so_ki_dien.Text == "")
                {
                    MessageBox.Show("Xin vui lòng nhập vào số kí điện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_so_ki_dien.Focus();
                    return false;
                }
                else if(txt_so_khoi_nuoc.Text == "")
                {
                    MessageBox.Show("Xin vui lòng nhập vào số khối nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_so_khoi_nuoc.Focus();
                    return false;
                }
            }
            if (ThuTienDAO_HHH.XemDanhSachDaThu_Theo_Ngay(tt) == true)
            {
                MessageBox.Show(string.Format("Khách hàng này đã thu rồi. Bạn không cần phải thu lại.\nThu vào lúc: {0}", sCat), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        public void HamtongTien()
        {
            double tongcong = double.Parse(txt_tien_dien.Text) + double.Parse(txt_tien_nuoc.Text) + double.Parse(txt_internet.Text);
            lbl_tong_tien_phai_tra.Text = string.Format("{0:0,0}", (tongcong + Convert.ToDouble(txt_tien_nha.Text)));
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_so_ki_dien.Enabled = true;
                btn_tinhtien.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                txt_so_ki_dien.Enabled = false;
                btn_tinhtien.Enabled = false;
            }
            else
            {
                txt_so_ki_dien.Enabled = false;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txt_so_khoi_nuoc.Enabled = true;
            }
            else
            {
                txt_so_khoi_nuoc.Enabled = false;
            }
        }

        private void txt_so_ki_dien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Tiendien = Convert.ToDouble(txt_so_ki_dien.Text) * 5000;
                txt_tien_dien.Text = Tiendien.ToString();
                HamtongTien();
            }
            catch
            {
                MessageBox.Show("Số kí điện phải là số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void txt_so_khoi_nuoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double tiennuoc = Convert.ToDouble(txt_so_khoi_nuoc.Text) * 8000;
                txt_tien_nuoc.Text = tiennuoc.ToString();
                HamtongTien();
            }
            catch
            {
                MessageBox.Show("Số nước phải là số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txt_internet.Text = "30000";
            }
            else if (checkBox3.Checked == false)
            {
                txt_internet.Text = "0";
            }
            HamtongTien();
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            if (BatLoi() == true)
            {
                //Khỏi cần thêm mã dịch vụ. Bởi bì bên lớp DAO đã gán rồi...
                //Chèn CheckBox1...
                if (checkBox1.Checked == true)
                {
                    tt.sMaPT = txt_ma_phong.Text;
                    tt.sMaKT = txt_ma_khach.Text;
                    if (checkBox1.Checked && txt_so_ki_dien.Text != "")
                    {
                        tt.sSoLuong = Convert.ToInt32(txt_so_ki_dien.Text);
                    }
                    else
                    {
                        tt.sSoLuong = 0;
                    }
                    string sCat = (date_ngay_thu.Text).Substring(3, 2) + "-" + (date_ngay_thu.Text).Substring(0, 2) + "-" + (date_ngay_thu.Text).Substring(6, 4);
                    tt.sNgayThu = sCat.ToString();
                    ThuTienDAO_HHH.Checkbox1(tt);
                }
                //Chèn CheckBox2...
                if (checkBox2.Checked == true)
                {
                    tt.sMaPT = txt_ma_phong.Text;
                    tt.sMaKT = txt_ma_khach.Text;
                    if (checkBox2.Checked && txt_so_khoi_nuoc.Text != "")
                    {
                        tt.sSoLuong = Convert.ToInt32(txt_so_khoi_nuoc.Text);
                    }
                    else
                    {
                        tt.sSoLuong = 0;
                    }
                    string sCat = (date_ngay_thu.Text).Substring(3, 2) + "-" + (date_ngay_thu.Text).Substring(0, 2) + "-" + (date_ngay_thu.Text).Substring(6, 4);
                    tt.sNgayThu = sCat.ToString();
                    ThuTienDAO_HHH.Checkbox2(tt);
                }

                //Chèn Checkbox3...
                if (checkBox3.Checked == true)
                {
                    tt.sMaPT = txt_ma_phong.Text;
                    tt.sMaKT = txt_ma_khach.Text;
                    tt.sSoLuong = 1;
                    string sCat = (date_ngay_thu.Text).Substring(3, 2) + "-" + (date_ngay_thu.Text).Substring(0, 2) + "-" + (date_ngay_thu.Text).Substring(6, 4);
                    tt.sNgayThu = sCat.ToString();
                    ThuTienDAO_HHH.Checkbox3(tt);
                }
                MessageBox.Show("Thu tiền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
           
        }

        //Hàm này để xác định thời gian đóng tiền gần nhất...
        public void Thoigiandongtiengannhat()
        {
            try
            {
                tt.sMaKT = txt_ma_khach.Text;
                DataTable dt;
                dt = ThuTienDAO_HHH.Datetimepicker3(tt);
                string sKQ = dt.Rows[0][0].ToString();
                DateTime ThoiGian = Convert.ToDateTime(sKQ);
                Datetime_ngay_dong_gan_nhat.Value = ThoiGian;
            }
            catch
            {
                string sKQ = (date_ngay_thue.Text);
                DateTime ThoiGianS = Convert.ToDateTime(sKQ);
                Datetime_ngay_dong_gan_nhat.Value = ThoiGianS;
            }
        }
        private void txt_ma_khach_TextChanged(object sender, EventArgs e)
        {
            Thoigiandongtiengannhat();
        }
        //Hàm đếm số ngày thuê...
        public void Tinhsongay()
        {
            DateTime date1 = Datetime_ngay_dong_gan_nhat.Value;
            DateTime date2 = date_ngay_thu.Value;
            System.TimeSpan Tru_Ngay = date2 - date1;
            txt_so_ngay_o.Text = Convert.ToString(Math.Round(Tru_Ngay.TotalDays, 0));

            if (Convert.ToInt32(txt_so_ngay_o.Text) < 0)
            {
                MessageBox.Show("Không được phép thu sau tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    date_ngay_thu.Value = Datetime_ngay_dong_gan_nhat.Value;
                }
            }


            //Phòng P001=============> P005
            if (txt_ma_phong.Text == "PT001" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT002" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT003" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT004" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT005" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10)
            {
                //Ở dưới 10 ngày mà yêu cầu tính tiền thì tiền sẽ tính là 1 ngày 20 ngàn...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 25000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 25000);
            }
            else if (txt_ma_phong.Text == "PT001" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT002" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT003" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT004" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT005" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20)
            {
                //Ở dưới 20 ngày mà yêu cầu tính thì sẽ tính 1 ngày 23...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 23000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 23000);
            }

            else if (txt_ma_phong.Text == "PT001" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT002" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT003" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT004" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT005" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27)
            {
                //Ở từ 21 ngày mà yêu cầu tính thì sẽ tính 1 ngày 20k...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 20000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 20000);
            }
            else if (txt_ma_phong.Text == "PT001" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT002" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT003" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT004" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT005" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31)
            {
                txt_tien_nha.Text = "500000";
                lbl_tong_tien_phai_tra.Text = "500000";
            }
            else if (txt_ma_phong.Text == "PT001" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT002" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT003" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT004" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT005" && Convert.ToInt32(txt_so_ngay_o.Text) > 31)
            {
                MessageBox.Show("Không được phép thu trước tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    date_ngay_thu.Value = Datetime_ngay_dong_gan_nhat.Value;
                }
            }




            //Phòng P006=======> P010
            if (txt_ma_phong.Text == "PT006" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT007" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT008" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT009" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10 || txt_ma_phong.Text == "PT010" && Convert.ToInt32(txt_so_ngay_o.Text) <= 10)
            {
                //Ở dưới 10 ngày mà yêu cầu tính tiền thì tiền sẽ tính là 1 ngày 20 ngàn...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 50000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 50000);
            }
            else if (txt_ma_phong.Text == "PT006" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT007" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT008" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT009" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20 || txt_ma_phong.Text == "PT010" && Convert.ToInt32(txt_so_ngay_o.Text) > 10 && Convert.ToInt32(txt_so_ngay_o.Text) <= 20)
            {
                //Ở dưới 20 ngày mà yêu cầu tính thì sẽ tính 1 ngày 23...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 40000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 40000);
            }

            else if (txt_ma_phong.Text == "PT006" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT007" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT008" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT009" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27 || txt_ma_phong.Text == "PT010" && Convert.ToInt32(txt_so_ngay_o.Text) > 20 && Convert.ToInt32(txt_so_ngay_o.Text) <= 27)
            {
                //Ở từ 21 ngày mà yêu cầu tính thì sẽ tính 1 ngày 20k...
                txt_tien_nha.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 38000);
                lbl_tong_tien_phai_tra.Text = Convert.ToString(Convert.ToInt32(txt_so_ngay_o.Text) * 38000);
            }
            else if (txt_ma_phong.Text == "PT006" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT007" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT008" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT009" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31 || txt_ma_phong.Text == "PT010" && Convert.ToInt32(txt_so_ngay_o.Text) > 27 && Convert.ToInt32(txt_so_ngay_o.Text) <= 31)
            {
                txt_tien_nha.Text = "1000000";
                lbl_tong_tien_phai_tra.Text = "1000000";
            }
            else if (txt_ma_phong.Text == "PT006" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT007" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT008" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT009" && Convert.ToInt32(txt_so_ngay_o.Text) > 31 || txt_ma_phong.Text == "PT010" && Convert.ToInt32(txt_so_ngay_o.Text) > 31)
            {
                MessageBox.Show("Không được phép thu trước tháng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    date_ngay_thu.Value = Datetime_ngay_dong_gan_nhat.Value;
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Tinhsongay();
        }
        private void Datetime_ngay_dong_gan_nhat_ValueChanged(object sender, EventArgs e)
        {
            Tinhsongay();
        }
    }
}