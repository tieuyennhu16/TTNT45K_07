using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using phongtro.FileKetNoiCSDL;
using phongtro.HeThongXuLy;
using System.Data;
using System.Data.SqlClient;

namespace phongtro.HeThongXuLy
{
    class TrangThaiThueDAO_HHH
    {
        static SqlConnection con;


        public static DataTable lay_Khu_Vuc()
        {
            string sTruyVan = "Select * From KHUVUC";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }

        public static DataTable lay_danh_sach_phong_tro()
        {
            string sTruyVan = "Select * From PHONGTRO";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }


        public static DataTable lay_danh_sach_khach_tro()
        {
            string sTruyVan = "Select * From khachtro";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }


        public static DataTable Chi_Tiet_Khach_Hang_Theo_Ma_Khu_Vuc(TrangThaiThueDTO_HHH trangthai)
        {
            string sTruyVan = "select ktro.MaKT, ptro.MaPT, ptro.TenPhong, ptro.SLToiDa, ktro.HoTen, ktro.DiaChi, ktro.GioiTinh, ktro.NgeNghiep, ktro.SDT from PHONGTRO ptro, KHACHTRO ktro, KHUVUC kv where ptro.MaPT= ktro.MaPT and kv.MaKV= ptro.MaKV and ptro.TrangThaiThue= 'True' and ktro.TrangthaiTro= 'True' and kv.MaKV= '" + trangthai.SKhuVuc + "'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }

        public static DataTable Chi_Tiet_Khach_Hang_Theo_Ma_Phong_Tro(TrangThaiThueDTO_HHH trangthai)
        {
            string sTruyVan = "select ktro.MaKT, ptro.MaPT, ptro.TenPhong, ptro.SLToiDa, ktro.HoTen, ktro.DiaChi, ktro.GioiTinh, ktro.NgeNghiep, ktro.SDT from PHONGTRO ptro, KHACHTRO ktro, KHUVUC kv where ptro.MaPT= ktro.MaPT and kv.MaKV= ptro.MaKV and ktro.TrangthaiTro= 'True' and ptro.MaPT= '" + trangthai.SMaPT + "'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }



        public static bool CapNhat(TrangThaiThueDTO_HHH trangthai)
        {
            try
            {
                string sTruyVan = "update KHACHTRO set HoTen=N'"+trangthai.sHoTen+"', DiaChi=N'"+trangthai.sDiaChi+"', NgeNghiep= N'"+trangthai.SNghenghiep+"', SDT= '"+trangthai.SDT+"' where MaKT= '"+trangthai.SMaKT+"'";
                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);
                DataAccess.DongKetNoi(con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
