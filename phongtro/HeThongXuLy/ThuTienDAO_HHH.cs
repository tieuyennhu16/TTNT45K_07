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
    class ThuTienDAO_HHH
    {
        static SqlConnection con;
        public static DataTable Load_Combobox()
        {
            string sTruyVan = "select kt.MaKT, kt.HoTen, kt.CMND, kt.GioiTinh, kt.NgeNghiep, kt.DiaChi, kt.TrangthaiTro, kt.ChuNha, pt.MaPT, pt.TenPhong, pt.SLToiDa, pt.TrangThai, pt.TrangThaiThue, pt.SoNguoiHienTai, thuephong.NgayThue from KHACHTRO kt, PHONGTRO pt, QUANLITHUEPHONG thuephong where pt.MaPT= kt.MaPT and kt.ChuNha= 'True' and pt.TrangThaiThue= 'True' and kt.MaKT= thuephong.MaKT and kt.TrangthaiTro= 'True'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }

        public static DataTable Datetimepicker3(ThuTienDTO_HHH tt)
        {
            string sTruyVan = "select top 1 NgayThu from QLTHUTIEN where MaKT= '"+tt.sMaKT+"' order by NgayThu desc";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }

        //Cho hiển thị tất cả các thành viên của phòng...
        public static DataTable Load_Datagridview(ThuTienDTO_HHH tt)
        {
            string sTruyVan = "select pt.MaPT, pt.MaKV, pt.TenPhong, pt.SoNguoiHienTai, pt.TrangThaiThue, kt.MaKT, kt.HoTen,kt.CMND, kt.GioiTinh, kt.NgeNghiep, kt.SDT, kt.DiaChi, kt.TrangthaiTro, kt.ChuNha from PHONGTRO pt, KHACHTRO kt where pt.MaPT= kt.MaPT and kt.ChuNha= 'False' and kt.TrangthaiTro= 'True' and pt.MaPT= '" + tt.sMaPT + "'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }
        //Xem danh sách đã thu theo ngày...
        public static bool XemDanhSachDaThu_Theo_Ngay(ThuTienDTO_HHH tt)
        {
           
                string sTruyVan = "select pt.MaPT, pt.TenPhong, pt.SLToiDa, kt.HoTen, kt.CMND, kt.NgeNghiep, kt.DiaChi, thutien.MaDV, thutien.Soluong, thutien.NgayThu from PHONGTRO pt, KHACHTRO kt, QLTHUTIEN thutien, DichVu dv where pt.MaPT= kt.MaPT and kt.MaKT= thutien.MaKT and kt.MaPT= thutien.MaPT and thutien.MaDV= dv.MaDV and kt.ChuNha= 'True' and thutien.NgayThu= '"+tt.sNgayThu+"' and thutien.MaKT='"+tt.sMaKT+"'";
                con = DataAccess.KetNoi();
                DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
                DataAccess.DongKetNoi(con);

                if (dt.Rows.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        //Xem danh sách khách hàng đã thu...
        public static DataTable XemDanhSachDaThu()
        {
            string sTruyVan = "select pt.MaPT, pt.TenPhong, pt.SLToiDa, kt.HoTen, kt.CMND, kt.NgeNghiep, kt.DiaChi, thutien.MaDV, thutien.Soluong, thutien.NgayThu from PHONGTRO pt, KHACHTRO kt, QLTHUTIEN thutien, DichVu dv where pt.MaPT= kt.MaPT and kt.MaKT= thutien.MaKT and kt.MaPT= thutien.MaPT and thutien.MaDV= dv.MaDV and kt.ChuNha= 'True'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static bool Checkbox1(ThuTienDTO_HHH tt)
        {
            try
            {
                string sTruyVan = "insert into QLTHUTIEN(MaDV, MaPT, MaKT, Soluong, NgayThu) values ('1', '"+tt.sMaPT+"', '"+tt.sMaKT+"', '"+tt.sSoLuong+"', '"+tt.sNgayThu+"')";
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


        public static bool Checkbox2(ThuTienDTO_HHH tt)
        {
            try
            {
                string sTruyVan = "insert into QLTHUTIEN(MaDV, MaPT, MaKT, Soluong, NgayThu) values ('2', '" + tt.sMaPT + "', '" + tt.sMaKT + "', '" + tt.sSoLuong + "', '" + tt.sNgayThu + "')";
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

        public static bool Checkbox3(ThuTienDTO_HHH tt)
        {
            try
            {
                string sTruyVan = "insert into QLTHUTIEN(MaDV, MaPT, MaKT, Soluong, NgayThu) values ('3', '" + tt.sMaPT + "', '" + tt.sMaKT + "', '" + tt.sSoLuong + "', '" + tt.sNgayThu + "')";
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


        public static bool KiemTraTrung(ThuTienDTO_HHH tt)
        {
            try
            {
                string sTruyVan = "select *from QLThuTien where MaPT='" + tt.sMaPT + "' and MaKT='" + tt.sMaKT + "' and Soluong= '" + tt.sSoLuong + "' and NgayThu= '" + tt.sNgayThu + "'";
                con = DataAccess.KetNoi();
                DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
                DataAccess.DongKetNoi(con);
                if (dt.Rows.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
