using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using phongtro.GUI;
using phongtro.HeThongXuLy;
using phongtro.HeThongGiaoDien;

namespace phongtro.GUI
{
    public partial class frm_Trangthaithue : UserControl
    {
        TrangThaiThueDTO_HHH trthai = new TrangThaiThueDTO_HHH();

        TreeView cay = new TreeView();
        TreeNode nodecha = new TreeNode();

        DataTable dt_khuvuc;
        DataTable dt_ds_phongtro;
        //DataTable dt_khachtro;
        public frm_Trangthaithue()
        {
            InitializeComponent();
        }

        private void frm_Trangthaithue_Load(object sender, EventArgs e)
        {
            Load_TreeView_Da_Thue();
            Load_Tree_View_Chua_Thue();
        }
        public void Load_TreeView_Da_Thue()
        {
            treeView1.Nodes.Clear();
            dt_khuvuc = TrangThaiThueDAO_HHH.lay_Khu_Vuc();
            int n = dt_khuvuc.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                nodecha = treeView1.Nodes.Add(dt_khuvuc.Rows[i]["TenKV"].ToString());
                nodecha.Tag = dt_khuvuc.Rows[i]["MaKV"].ToString();
                //Add nút con...
                dt_ds_phongtro = TrangThaiThueDAO_HHH.lay_danh_sach_phong_tro();
                int soluongphong = dt_ds_phongtro.Rows.Count;

                for (int j = 0; j < soluongphong; j++)
                {
                    if (dt_khuvuc.Rows[i]["MaKV"].ToString() == dt_ds_phongtro.Rows[j]["MaKV"].ToString() && dt_ds_phongtro.Rows[j]["TrangThaiThue"].ToString() == "True")
                    {
                        TreeNode nodecon = new TreeNode();
                        nodecon.Text = dt_ds_phongtro.Rows[j]["TenPhong"].ToString();
                        nodecon.Tag = dt_ds_phongtro.Rows[j]["MaPT"].ToString();
                        nodecha.Nodes.Add(nodecon);
                    }
                }
            }
        }

        public void Load_Tree_View_Chua_Thue()
        {
            treeView2.Nodes.Clear();

            dt_khuvuc = TrangThaiThueDAO_HHH.lay_Khu_Vuc();
            int n = dt_khuvuc.Rows.Count;

            for (int i = 0; i < n; i++)
            {
                nodecha = treeView2.Nodes.Add(dt_khuvuc.Rows[i]["TenKV"].ToString());
                nodecha.Tag = dt_khuvuc.Rows[i]["MaKV"].ToString();
                //Add nút con...
                dt_ds_phongtro = TrangThaiThueDAO_HHH.lay_danh_sach_phong_tro();
                int soluongphong = dt_ds_phongtro.Rows.Count;

                for (int j = 0; j < soluongphong; j++)
                {
                    if (dt_khuvuc.Rows[i]["MaKV"].ToString() == dt_ds_phongtro.Rows[j]["MaKV"].ToString() && dt_ds_phongtro.Rows[j]["TrangThaiThue"].ToString() == "False")
                    {
                        TreeNode nodecon = new TreeNode();
                        nodecon.Text = dt_ds_phongtro.Rows[j]["TenPhong"].ToString();
                        nodecon.Tag = dt_ds_phongtro.Rows[j]["MaPT"].ToString();
                        nodecha.Nodes.Add(nodecon);
                    }
                }
            }
        }

        public void Load_Xuong_DataGridview()
        {
            string sTag = treeView1.SelectedNode.Tag.ToString();

            if (sTag.Contains("KV"))
            {
                trthai.SKhuVuc = treeView1.SelectedNode.Tag.ToString();
                DataTable dt;
                dt = TrangThaiThueDAO_HHH.Chi_Tiet_Khach_Hang_Theo_Ma_Khu_Vuc(trthai);
                dataGridView1.DataSource = dt;
            }

            else if (sTag.Contains("PT"))
            {
                trthai.SMaPT = treeView1.SelectedNode.Tag.ToString();
                DataTable dt;
                dt = TrangThaiThueDAO_HHH.Chi_Tiet_Khach_Hang_Theo_Ma_Phong_Tro(trthai);
                dataGridView1.DataSource = dt;
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Load_Xuong_DataGridview();
        }
        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cap_Nhat_Trang_Thai_Thue_HHH a = new Cap_Nhat_Trang_Thai_Thue_HHH();
                a.makhachtro = dataGridView1.SelectedRows[0].Cells["MaKT"].Value.ToString();
                a.Maphong = dataGridView1.SelectedRows[0].Cells["MaPT"].Value.ToString();
                a.hoten = dataGridView1.SelectedRows[0].Cells["HoTen"].Value.ToString();
                a.diachi = dataGridView1.SelectedRows[0].Cells["DiaChi"].Value.ToString();
                a.nghenghiep = dataGridView1.SelectedRows[0].Cells["NgeNghiep"].Value.ToString();
                a.sdt = dataGridView1.SelectedRows[0].Cells["SDT"].Value.ToString();
                a.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Hãy chọn 1 dòng muốn chỉnh sửa nội dung.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chuyểnPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PhieuThue a = new frm_PhieuThue();

            a.sMaPT = treeView2.SelectedNode.Tag.ToString();
            if (treeView2.SelectedNode.Tag.ToString().Contains("KV"))
            {
                MessageBox.Show("Xin vui lòng chọn phòng muốn thuê..\nKhông được chọn cả khu vực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (treeView2.SelectedNode.Tag.ToString().Contains("PT"))
            {
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn phòng muốn thuê..\nKhông được chọn cả khu vực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_PhieuThue a = new frm_PhieuThue();

            a.sMaPT = treeView1.SelectedNode.Tag.ToString();
            if (treeView1.SelectedNode.Tag.ToString().Contains("KV"))
            {
                MessageBox.Show("Xin vui lòng chọn phòng muốn thuê..\nKhông được chọn cả khu vực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (treeView1.SelectedNode.Tag.ToString().Contains("PT"))
            {
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Xin vui lòng chọn phòng muốn thuê..\nKhông được chọn cả khu vực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
