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
    
    class ThietBi_DAO_HHH
    {
        static SqlConnection con;
        public static DataTable LayDanhSachThietBi()
        {
            string sTruyVan = "Select * From thietbi";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }


        //Load mã phòng...
        public static DataTable LayDanhSachPhong()
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
        public static bool Them(ThietBi_DTO_HHH tb)
        {
            try
            {
                string sTruyVan = "insert into THIETBI(MaPT, TenTB, NhanHieu, SoLuong, TinhTrang, NgayMua, Gia) values ('" + tb.SMaPT + "', N'" + tb.STenTB + "', N'" + tb.SNhanHieu + "', N'" + tb.SSoLuong + "', '" + tb.STinhTrang + "', '" + tb.SNgaymua + "', '" + tb.SGia + "')";
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



        public static bool CapNhat(ThietBi_DTO_HHH tb)
        {
            try
            {
                string sTruyVan = "update THIETBI set MaPT= '"+tb.SMaPT+"', TenTB= '"+tb.STenTB+"', NhanHieu='"+tb.SNhanHieu+"', SoLuong='"+tb.SSoLuong+"', TinhTrang='"+tb.STinhTrang+"', NgayMua='"+tb.SNgaymua+"', Gia='"+tb.SGia+"' where MaTB= '"+tb.SMaTB+"'";
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


        public static bool Xoa(ThietBi_DTO_HHH tb)
        {
            try
            {
                string sTruyVan = "delete THIETBI where MaTB= '"+tb.SMaTB+"'";
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
