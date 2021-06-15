using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.HeThongXuLy;
using System.Diagnostics;
using System.IO;

namespace phongtro.HeThongGiaoDien
{
    public partial class SaoLuu_HHH : Form
    {

        SaoLuuDuLieuDTO_HHH sl = new SaoLuuDuLieuDTO_HHH();
        public SaoLuu_HHH()
        {
            InitializeComponent();
        }
        public void tudongtaobansaoluu()
        {
            Directory.CreateDirectory("C:\\QLNHATRO\\FileBackup\\DuPhong\\");
            try
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                int hours = DateTime.Now.Hour;
                int Mn = DateTime.Now.Minute;
                int sc = DateTime.Now.Second;

                string ngay = Convert.ToString(day);
                string thang = Convert.ToString(month);
                string nam = Convert.ToString(year);
                string gio = Convert.ToString(hours);
                string phut = Convert.ToString(Mn);
                string giay = Convert.ToString(sc);

                string tonghop = "" + ngay + "-" + thang + "-" + nam + "-" + gio + "h." + phut + "m." + giay + "s";


                string noiluu = "C:\\QLNHATRO\\FileBackup\\DuPhong\\";
                string ten_file = "" + tonghop.ToString() + "";
                string bak = ".bak";
                string Tentaptinluuxuongdia = string.Concat(noiluu, ten_file, bak);
                sl.STenTep = Tentaptinluuxuongdia.ToString();
                SaoLuuDuLieuDAO_HHH.Saoluu(sl);
            }
            catch
            {

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

              
                if (bayloi() == 1)
                {
                    return;
                }
                string noiluu = txt_noi_luu.Text;
                string ten_file = txt_ten_file.Text;
                string bak = ".bak";
                string tenfile = string.Concat(noiluu, ten_file, bak);
                sl.STenTep = tenfile.ToString();
                string kiemtratontaifile = "C:\\QLNHATRO\\FileBackup\\" + ten_file + ".bak";
                if (System.IO.File.Exists(kiemtratontaifile))
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Tên tập tin bị trùng.\nXin vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    pictureBox1.Visible = true;
                    btn_xac_nhan.Visible = false;
                    btn_mo_thu_muc.Visible = false;
                    label2.Visible = false;
                    label1.Visible = false;
                    txt_ten_file.Visible = false;
                    txt_noi_luu.Visible = false;

                    SaoLuuDuLieuDAO_HHH.Saoluu(sl);

                    pictureBox1.Visible = false;
                    MessageBox.Show("Sao lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DialogResult dl = MessageBox.Show("Bạn có muốn mở thư mục vừa sao lưu hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dl == DialogResult.Yes)
                    {
                        Process.Start("C:\\QLNHATRO");
                    }

                }

            }
            catch
            {
                MessageBox.Show("Sao lưu thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int bayloi()
        {
            if (txt_ten_file.Text == "")
            {
                MessageBox.Show("Hãy nhập tên tập tin muốn sao lưu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ten_file.Focus();
                return 1;
            }
            else
                return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\QLNHATRO\\FileBackup\\");
        }

        private void Backup_HHH_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\QLNHATRO\\FileBackup\\DuPhong\\");
            pictureBox1.Visible = false;
        }

    }
}
