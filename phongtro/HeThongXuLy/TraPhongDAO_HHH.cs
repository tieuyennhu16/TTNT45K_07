using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using phongtro.FileKetNoiCSDL;
namespace phongtro.HeThongXuLy
{
    class TraPhongDAO_HHH
    {
        static SqlConnection con;


        //Cho hiển thị duy nhất chủ nhà để tiện cho việc tính toán và thâu tiền...
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

        //Cho hiển thị tất cả các thành viên của phòng...
        public static DataTable Load_Datagridview(TraPhongDTO_HHH traphong)
        {
            string sTruyVan = "select pt.MaPT, pt.MaKV, pt.TenPhong, pt.SoNguoiHienTai, pt.TrangThaiThue, kt.MaKT, kt.HoTen,kt.CMND, kt.GioiTinh, kt.NgeNghiep, kt.SDT, kt.DiaChi, kt.TrangthaiTro, kt.ChuNha from PHONGTRO pt, KHACHTRO kt where pt.MaPT= kt.MaPT and kt.ChuNha= 'False' and kt.TrangthaiTro= 'True' and pt.MaPT= '" + traphong.sMaPT + "'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }
        //B0: Ghi xuống CSDL các thông tin trong bảng TRAPHONG
        public static bool Them(TraPhongDTO_HHH traphong)
        {
            try
            {
                string sTruyVan = "insert into TRAPHONG(MaKT, TenKT, NgayTra, GhiChu) values (N'"+traphong.sMaKT+"', N'"+traphong.sTenKT+"', '"+traphong.sNgayTra+"', N'"+traphong.sGhiChu+"')";
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
        //B1: Muốn trả phòng thì phải chuyển chủ nhà trọ về trạng thái false...
        public static bool Update_ChuNha_False(TraPhongDTO_HHH traphong)
        {
            try
            {
                string sTruyVan = "update KHACHTRO set ChuNha= 'False' where MaKT= '" + traphong.sMaKT + "'";
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
        //B2: Chuyển nguyên cái phòng đó về false hết
        public static bool Update_Tat_Ca_Phong_False(TraPhongDTO_HHH traphong)
        {
            try
            {
                string sTruyVan = "update KHACHTRO set TrangthaiTro= 'false' where MaPT= '"+traphong.sMaPT+"'";
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
        //B3: Bật lại False trong bảng PHONGTRO(Để báo là phòng đó còn trống)
        public static bool Update_Trang_Thai_False_PHONGTRO(TraPhongDTO_HHH traphong)
        {
            try
            {
                string sTruyVan = "update PHONGTRO set TrangThaiThue= 'False' where MaPT= '" + traphong.sMaPT + "'";
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

        //B4: Hàm kiểm tra có trùng tên trong SQL TRAPHONG hay không. Nếu trùng hoàn toàn thì không tiếp tục ghi thêm nữa mà giữ lại bản củ.

        public static bool KiemTraTrung(TraPhongDTO_HHH traphong)
        {
            try
            {
                string sTruyVan = "select MaKT from TRAPHONG where MaKT='"+traphong.sMaKT+"'";
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
