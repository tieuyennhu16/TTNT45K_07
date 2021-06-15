using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using phongtro.HeThongXuLy;



namespace phongtro.GUI
{
    public partial class frm_PhieuThue : Form
    {
        public string sMaPT { get; set; }
        PHIEUTHUE_DTO pt = new PHIEUTHUE_DTO();
        KHACHTRO_DTO kt = new KHACHTRO_DTO();
        public frm_PhieuThue()
        {
            InitializeComponent();
        }

        //Đếm số người hiện tại... 
        //Hiển thị lên textbox.
        public void LaysoNguoiHienTai()
        {
            pt.MaPT = txtmaphong.Text;
            DataTable dt;
            dt = PHIEUTHUE_DAO.DemsoNguoiHienTai(pt);
            txt_so_nguoi_hien_tai.Text = Convert.ToString(dt.Rows.Count);
        }
        //Hàm kiểm tra..
        //Dựa vào textbox để so sánh, nếu mà nhỏ hơn số người tối đa thì mới cho thêm...
        public bool KiemTraDieuKien()
        {
            //Nếu số lượng tối đa lớn hơn số lượng người hiện tại thì cho thêm...

            if (Convert.ToInt32(txt_so_luong_toi_da.Text) > Convert.ToInt32(txt_so_nguoi_hien_tai.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void frm_PhieuThue_Load(object sender, EventArgs e)
        {
            //Lấy được cái mã phòng thuê...
            txtmaphong.Text = sMaPT.ToString();
            //=================================

            LaysoNguoiHienTai();
            Load_Datagridview();
            lblmaphieu.Visible = false;
        }
        public void Load_Datagridview()
        {
            DataTable dt;
            dt = PHIEUTHUE_DAO.Lay_DSKHACHTRO_PHIEUTHUE();
            dgvTTkhachthue.DataSource = dt;
            Tencolumns();
            btn_Luu.Enabled = false;
            btn_Capnhat.Enabled = true;
            btnin.Enabled = true;
            btn_Them.Enabled = true;
            btntimkiem.Enabled = true;
            grupbox_tttkhachthue.Enabled = true;
            groupbox_ttkhachtro.Enabled = true;
            grupbox_timkiem.Enabled = true;

        }
        public void Tencolumns()
        {
            //select ql.MaPhieuThue,PT.MaPT,TenPhong, KT.MaKT,HoTen,CMND,GioiTinh,NgeNghiep,DiaChi,SDT,ChuNha,kv.MaKV,TenKV,Tang ,kv.DAY ,NgayThue,TienDatCoc,GiaTien
            dgvTTkhachthue.Columns["MaPhieuThue"].Visible = false;
            dgvTTkhachthue.Columns["MaPT"].Visible = false;
            dgvTTkhachthue.Columns["TenPhong"].HeaderText = "Phòng";
            dgvTTkhachthue.Columns["MaKT"].HeaderText = "Mã khách trọ";
            dgvTTkhachthue.Columns["HoTen"].HeaderText = "Họ tên";
            dgvTTkhachthue.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvTTkhachthue.Columns["NgeNghiep"].HeaderText = "Nghề nghiệp";
            dgvTTkhachthue.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvTTkhachthue.Columns["ChuNha"].Visible = false;
            dgvTTkhachthue.Columns["MaKV"].Visible = false;
            dgvTTkhachthue.Columns["TenKV"].Visible = false;
            dgvTTkhachthue.Columns["Tang"].Visible = false;
            dgvTTkhachthue.Columns["DAY"].Visible = false;
            dgvTTkhachthue.Columns["NgayThue"].HeaderText = "Ngày thuê";
            dgvTTkhachthue.Columns["TienDatCoc"].HeaderText = "Tiền đặt cọc";
            dgvTTkhachthue.Columns["GiaTien"].HeaderText = "Giá tiền";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (KiemTraDieuKien() == true)
            {
                txthoten.Clear();
                txtcmnd.Clear();
                txtnghenghiep.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
                txttiendatcoc.Clear();
                KTraChuNha();
                chkchunha.Checked = false;
                //kt001
                DataTable dt;
                dt = PHIEUTHUE_DAO.Lay_DSKHACHTRO_MAX();

                DataRow DR = dt.Rows[dt.Rows.Count - 1];
                txtmakt.Text = DR["MaKT"].ToString();
                string chuoibandau = txtmakt.Text;
                string scat = chuoibandau.Substring(3, 2);
                int kq = Convert.ToInt32(scat) + 1;
                if (kq < 10)
                {
                    string schuoi = "KT00";
                    txtmakt.Text = string.Concat(schuoi, kq);
                }
                else if (kq >= 10)
                {
                    string schuoi = "KT0";
                    txtmakt.Text = string.Concat(schuoi, kq);
                }
                btn_Luu.Enabled = true;
                btn_Capnhat.Enabled = false;
                btnin.Enabled = false;
                txttiendatcoc.ReadOnly = false;
                btn_Them.Enabled = false;
                grupbox_timkiem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Phòng đã đầy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvTTkhachthue_Click(object sender, EventArgs e)
        {
            lblmaphieu.Visible = true;
            try
            {
                txtmakt.Text = dgvTTkhachthue.SelectedRows[0].Cells["MaKT"].Value.ToString();
                txthoten.Text = dgvTTkhachthue.SelectedRows[0].Cells["HoTen"].Value.ToString();
                txtcmnd.Text = dgvTTkhachthue.SelectedRows[0].Cells["CMND"].Value.ToString();
                txtdiachi.Text = dgvTTkhachthue.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                txtnghenghiep.Text = dgvTTkhachthue.SelectedRows[0].Cells["NgeNghiep"].Value.ToString();
                lblmaphieu.Text = dgvTTkhachthue.SelectedRows[0].Cells["MaPhieuThue"].Value.ToString();
                //cbxkhuvuc.SelectedValue = dgvTTkhachthue.SelectedRows[0].Cells["MaKV"].Value.ToString();
                txttiendatcoc.Text = dgvTTkhachthue.SelectedRows[0].Cells["TienDatCoc"].Value.ToString();
                txtmaphong.Text = dgvTTkhachthue.SelectedRows[0].Cells["MaPT"].Value.ToString();
                cbxGioitinh.Text = dgvTTkhachthue.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
                txtngaythue.Text = dgvTTkhachthue.SelectedRows[0].Cells["NgayThue"].Value.ToString();
                txtsdt.Text = dgvTTkhachthue.SelectedRows[0].Cells["SDT"].Value.ToString();
                if (dgvTTkhachthue.SelectedRows[0].Cells["ChuNha"].Value.ToString() == "True")
                {
                    chkchunha.Checked = true;
                    chkchunha.Enabled = true;
                }

                else
                {
                    chkchunha.Checked = false;
                    chkchunha.Enabled = false;
                }
                txttiendatcoc.ReadOnly = true;

                try
                {
                    if (txttiendatcoc.Text.Equals("0"))
                        return;
                    double temp = Convert.ToDouble(txttiendatcoc.Text);
                    txttiendatcoc.Text = temp.ToString("#,###");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex);
                }
            }
            catch (Exception ex)
            { }
        }


        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (KiemTraDieuKien() == true)
            {
                //Các biến DTO để truyền vào bảng KHÁCH TRỌ
                kt.MaPT = txtmaphong.Text;
                kt.HoTen = txthoten.Text;
                kt.MaKT = txtmakt.Text;
                kt.NgheNghiep = txtnghenghiep.Text;
                kt.DiaChi = txtdiachi.Text;
                kt.CMND = txtcmnd.Text;
                kt.SDT = txtsdt.Text;
                if (chkchunha.Checked == true)
                {
                    kt.ChuNha = "True";
                }
                else
                {
                    kt.ChuNha = "False";
                }

                if (cbxGioitinh.Text == "Nam")
                {
                    kt.GioiTinh = "Nam";
                }
                else
                {
                    kt.GioiTinh = "Nữ";
                }
                //======================================

                if (txtmaphong.Text == "")
                {
                    MessageBox.Show("Chưa chọn phòng từ danh sách phòng trống");
                    txtmaphong.Focus();
                    return;
                }
                if (txthoten.Text == "")
                {
                    MessageBox.Show("Nhâp lại họ tên khách trọ.");
                    txthoten.Focus();
                    return;
                }
                //========================================




                //DTO chèn vô bảng QUANLYTHUEPHONG...

                if (chkchunha.Checked == true)
                {
                    try
                    {
                        pt.TienDatCoc = int.Parse(txttiendatcoc.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhâp lại tiền đặt cọc \n");
                        txttiendatcoc.Focus();
                        return;
                    }
                }
                else if (chkchunha.Checked == false)
                {
                    pt.TienDatCoc = 0;
                    txttiendatcoc.Enabled = false;
                }
                string scat = (txtngaythue.Text).Substring(3, 2) + "-" + (txtngaythue.Text).Substring(0, 2) + "-" + (txtngaythue.Text).Substring(6, 4);
                pt.NgayThue = scat.ToString();
                pt.MaKT = txtmakt.Text;
                //============================================



                //DTO chèn vô bảng PHONGTRO
                //Để cập nhật trạng thái phòng...
                pt.MaPT = txtmaphong.Text;
                //============================================

                if ((PHIEUTHUE_DAO.Save(kt) == true) && (PHIEUTHUE_DAO.DANGKY(pt) == true) && (PHIEUTHUE_DAO.UPDATEtrangthaiphong(pt) == true))
                {
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LaysoNguoiHienTai();
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Load_Datagridview();

                //LOAD_PHONGTHEOKHUVUC();
                btn_Capnhat.Enabled = true;
                btnin.Enabled = true;
                grupbox_tttkhachthue.Enabled = true;
                groupbox_ttkhachtro.Enabled = true;
                grupbox_timkiem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Phòng đã đầy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtmaphong_TextChanged(object sender, EventArgs e)
        {

            if (txtmaphong.Text == "PT001" || txtmaphong.Text == "PT002" || txtmaphong.Text == "PT003" || txtmaphong.Text == "PT004" || txtmaphong.Text == "PT005")
            {
                txt_ma_kv.Text = "KV01";
                txt_ten_khu_vuc.Text = "Khu vực 1";
                txt_so_luong_toi_da.Text = "3";
                txt_gia_tien.Text = "500000";
            }
            else if (txtmaphong.Text == "PT006" || txtmaphong.Text == "PT007" || txtmaphong.Text == "PT008" || txtmaphong.Text == "PT009" || txtmaphong.Text == "PT010")
            {
                txt_ma_kv.Text = "KV02";
                txt_ten_khu_vuc.Text = "Khu vực 2";
                txt_so_luong_toi_da.Text = "5";
                txt_gia_tien.Text = "1000000";
            }
            KTraChuNha();
        }


        //Kiểm tra chủ nhà...
        public void KTraChuNha()
        {
            pt.MaPT = txtmaphong.Text;
            DataTable dt;
            dt = PHIEUTHUE_DAO.kiemtrachuphong(pt);
            if (dt.Rows.Count != 0)
            {
                chkchunha.Enabled = false;
            }
            else
            {
                chkchunha.Enabled = true;
            }
        }
        private void btn_Capnhat_Click(object sender, EventArgs e)
        {

            try
            {
                kt.HoTen = txthoten.Text;
                kt.NgheNghiep = txtnghenghiep.Text;
                kt.DiaChi = txtdiachi.Text;
                kt.CMND = txtcmnd.Text;
                kt.SDT = txtsdt.Text;
                kt.MaKT = txtmakt.Text;
                if (cbxGioitinh.Text == "Nam")
                {
                    kt.GioiTinh = "Nam";
                }
                else
                {
                    kt.GioiTinh = "Nữ";
                }
                if (PHIEUTHUE_DAO.UPDATE(kt) == true)
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Load_Datagridview();

            }
            catch (Exception ex)
            {
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("'Hôm nay: Ngày 'dd' Tháng 'MM' Năm 'yyyy',' hh:mm:ss");
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvTTkhachthue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvTTkhachthue.Columns["TienDatCoc"].DefaultCellStyle.Format = "#,###";
            dgvTTkhachthue.Columns["GiaTien"].DefaultCellStyle.Format = "#,###";
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            pt.MaPT = txttimkiem.Text;
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Hãy nhập vào từ khóa cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt;
            dt = PHIEUTHUE_DAO.SEARCH(pt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvTTkhachthue.DataSource = dt;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txthoten.Text = "";
            txtnghenghiep.Text = "";
            txttiendatcoc.Text = "";
            txtmakt.Text = "";
            txtmaphong.Text = "";
            txtngaythue.Text = "";
            txtdiachi.Text = "";
            txtcmnd.Text = "";
            cbxGioitinh.Text = "";
            txtsdt.Text = "";
            Load_Datagridview();
        }

        private void txttimkiem_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void chkchunha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchunha.Checked == false)
            {
                txttiendatcoc.Enabled = false;
            }
        }

        private void frm_PhieuThue_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frm_Trangthaithue a = new frm_Trangthaithue();
            //a.Show();
        }

        private void btnin_Click(object sender, EventArgs e)
        {

        }
    }
}
