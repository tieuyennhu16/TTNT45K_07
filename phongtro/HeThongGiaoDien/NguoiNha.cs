using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using phongtro.GUI;
using phongtro.HeThongGiaoDien;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace phongtro.HeThongGiaoDien
{
    public partial class NguoiNha : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public NguoiNha()
        {
            InitializeComponent();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Trạng thái thuê")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                //Khởi tạo lại cái Class...
                TabAdd a = new TabAdd();
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                a.AddTab(xtraTabControl1, "", "Trạng thái thuê", new frm_Trangthaithue());
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        public class TabAdd
        {

            // Xây dựng hàm dùng để add XtratabPage và XtraTabcontrol (Hàm này đặt trong Project có dạng Library để Build thành file .dll . Mục đích : viết 1 lần nhưng sử dụng cho nhiều Project khác nhau)
            // Sử dụng 4 đối số truyền vào cho hàm này gồm có:


            //1> DevExpress.XtraTab.XtraTabControl XtraTabCha : Tạm gọi là Tab Cha vì XtraTabControl này để mình quăng tabcon vào
            //2> string icon : Khi add Tab con vào Tab cha thì đối số này để quy định icon hình cho tabCon(XtraTabpage)
            //3> string TabNameAdd : Khi add tab con vào thì đối số này quy định tên của Tabcon vừa Add vào đó.
            //4> System.Windows.Forms.UserControl UserControl: Cái này dùng để Add cái UserControl do ta tạo vào Tabcon
            // Đướng đi: Khi gọi hàm này phải truyền vào 4 đối số để biết: 
            //Anh muốn add 1 cái Tab con vào cái tab Cha nào?
            // Anh muốn đặt tên Tab con đó tên là gì?
            // anh muốn cái Tab con khi add vào thì Icon của nó là gì?
            // Anh muốn đặt cái gì vào trong cái Tab Con đó trước khi quăng nó lên TAb Cha?
            // Note : Các bạn có thể tùy biến nhiều đối số khác nữa nhé.
            public void AddTab(DevExpress.XtraTab.XtraTabControl XtraTabCha, string icon, string TabNameAdd, System.Windows.Forms.UserControl UserControl)
            {
                // Khởi tạo 1 Tab Con (XtraTabPage) 
                DevExpress.XtraTab.XtraTabPage TAbAdd = new DevExpress.XtraTab.XtraTabPage();

                // Đặt đại cái tên cho nó là TestTab (Đây là tên nhé)
                TAbAdd.Name = "TestTab";
                // Tên của nó là đối số như đã nói ở trên
                TAbAdd.Text = TabNameAdd;
                // Add đối số UserControl vào Tab con vừa khởi tạo ở trên
                TAbAdd.Controls.Add(UserControl);
                // Dock cho nó tràn hết TAb con đó
                UserControl.Dock = DockStyle.Fill;
                try
                {
                    // Icon của Tab con khi add vào Tab cha sẽ được quy định ở đây(cái này các bác tự chọn đường dẫn đến file Icon đó nhé)
                    TAbAdd.Image = System.Drawing.Bitmap.FromFile(System.Windows.Forms.Application.StartupPath.ToString() + @"\Icons\" + icon);
                }
                catch (Exception e)
                {
                }
                // Quăng nó lên TAb Cha (XtraTabCha là đối số thứ nhất như đã nói ở trên) 
                XtraTabCha.TabPages.Add(TAbAdd);
            }
        }

        private void NguoiNha_Load(object sender, EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();


            //DevExpress.UserSkins.OfficeSkins.Register();

            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(ribbonGalleryBarItem5, true);





            // Viết thêm cái dòng này để tạo ra cái button header đó
            this.xtraTabControl1.HeaderButtons = DevExpress.XtraTab.TabButtons.Close;
            // them dong nay de cai nut do xuat hien o tat ca cac tab
            xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 145);
            //LookAndFeel.SkinName = "Black";



            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Trạng thái thuê")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                //Khởi tạo lại cái Class...
                TabAdd a = new TabAdd();
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                a.AddTab(xtraTabControl1, "", "Trạng thái thuê", new frm_Trangthaithue());
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Thu tiền phòng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                //Khởi tạo lại cái Class...
                TabAdd a = new TabAdd();
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                a.AddTab(xtraTabControl1, "", "Thu tiền phòng", new TinhTienTro_HHH());
            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Trả phòng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                //Khởi tạo lại cái Class...
                TabAdd a = new TabAdd();
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                a.AddTab(xtraTabControl1, "", "Trả phòng", new frm_PhieuTraPhong());
            }
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Hình ảnh phòng")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
                //Khởi tạo lại cái Class...
                TabAdd a = new TabAdd();
                // Nếu chưa có TAb này thì gọi hàm Addtab xây dựng ở trên để Add Tab con vào
                a.AddTab(xtraTabControl1, "", "Hình ảnh phòng", new HinhAnhPhong());
            }
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {

            DevExpress.XtraTab.XtraTabControl tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            (arg.Page as DevExpress.XtraTab.XtraTabPage).Dispose();
        }

        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {
            // Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }
    }
}