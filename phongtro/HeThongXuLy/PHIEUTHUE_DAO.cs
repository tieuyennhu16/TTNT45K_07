using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using phongtro.FileKetNoiCSDL;

namespace phongtro.HeThongXuLy
{
    class PHIEUTHUE_DAO
    {
        static SqlConnection con;
        public static DataTable SEARCH(PHIEUTHUE_DTO pt)
        {
            string sTruyVan = string.Format("select *from KHACHTRO KTRO, PHONGTRO PTRO where PTRO.MaPT= ktro.MaPT and KTRO.MaPT= '" + pt.MaPT + "'");
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }

        //Đếm số người hiện tại, nếu lớn hơn số người hiện tại thì "không" cho phép thêm nữa...
        //Nếu nhỏ hơn muốn thêm thì được...
        public static DataTable DemsoNguoiHienTai(PHIEUTHUE_DTO pt)
        {
            string sTruyVan = "select *from KHACHTRO KTRO, PHONGTRO PTRO where PTRO.MaPT= ktro.MaPT and KTRO.TrangthaiTro= 'True' and KTRO.MaPT= '"+pt.MaPT+"'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static DataTable Loc_theophongtro(string mapt)
        {
            string sTruyVan = "select ql.MaPhieuThue,PT.MaPT,TenPhong, KT.MaKT,HoTen,CMND,GioiTinh,NgeNghiep,DiaChi,SDT,ChuNha,kv.MaKV,TenKV,Tang ,kv.DAY ,NgayThue,TienDatCoc,GiaTien from KHACHTRO kt,PHONGTRO pt,QUANLITHUEPHONG ql,KHUVUC kv,BangGiaTien bg where kv.MaKV=bg.MaKV and kv.MaKV=pt.MaKV and pt.MaPT=kt.MaPT and ql.MaKT=kt.MaKT and ql.TrangThai='True'and pt.MaPT ='" + mapt + "'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }

       
        public static DataTable Lay_DSKHACHTRO_PHIEUTHUE()
        {
            string sTruyVan = "select ql.MaPhieuThue,PT.MaPT,TenPhong, KT.MaKT,HoTen,CMND,GioiTinh,NgeNghiep,DiaChi,SDT,ChuNha,kv.MaKV,TenKV,Tang ,kv.DAY ,NgayThue,TienDatCoc,GiaTien from KHACHTRO kt,PHONGTRO pt,QUANLITHUEPHONG ql,KHUVUC kv,BangGiaTien bg where kv.MaKV=bg.MaKV and kv.MaKV=pt.MaKV and pt.MaPT=kt.MaPT and ql.MaKT=kt.MaKT and ql.TrangThai='True'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);

            return dt;
        }
        

        public static DataTable kiemtrachuphong(PHIEUTHUE_DTO pt)
        {
            string sTruyVan = "select KT.MaKT,PT.MaPT, KT.TrangthaiTro, KT.ChuNha  from KHACHTRO kt,PHONGTRO pt where kt.MaPT=pt.MaPT and KT.TrangthaiTro = 'True'and KT.ChuNha='True'AND PT.MaPT='"+ pt.MaPT +"'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static DataTable Lay_DSKHACHTRO_MAX()
        {
            string sTruyVan = "SELECT TOP 1 * FROM KHACHTRO  ORDER BY MaKT DESC ";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }

        public static DataTable Lay_DSKhuvuc()
        {
            string sTruyVan = "select MaKV,TenKV from KHUVUC ";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static DataTable TTPHONGTRO_CBX()
        {
            string sTruyVan = "select mapt,tenphong from phongtro";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static DataTable Lay_DSPhongtro(string MaPT)
        {
            string sTruyVan = "select pt.MaPT,pt.TenPhong,pt.SoNguoiHienTai ,KV.MaKV,kv.TenKV,kv.TANG,KV.DAY,GiaTien  from KHUVUC KV,BANGGIATIEN BG,PHONGTRO PT WHERE KV.MaKV=BG.MaKV AND pt.MaKV =kv.MaKV and pt.TrangThai='true' and PT.MaPT= '" + MaPT + "'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static DataTable Lay_KHUVUCtheoma(string MA)
        {
            string sTruyVan = "select pt.MaPT,pt.TenPhong,pt.SoNguoiHienTai ,KV.MaKV,kv.TenKV,kv.TANG,KV.DAY,GiaTien  from KHUVUC KV,BANGGIATIEN BG,PHONGTRO PT WHERE KV.MaKV=BG.MaKV AND pt.MaKV =kv.MaKV and pt.TrangThai='true' and PT.TrangThaiThue ='false'and KV.MaKV= '" + MA + "'";
            con = DataAccess.KetNoi();
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            DataAccess.DongKetNoi(con);
            return dt;
        }
        public static bool Save(KHACHTRO_DTO kt)
        {
            try
            {
                string sTruyVan = "insert into KHACHTRO([MaKT],[MaPT],[HoTen],[CMND],[GioiTinh],[NgeNghiep],[DiaChi],[SDT],[TrangthaiTro],[ChuNha]) values ('" + kt.MaKT + "','" + kt.MaPT + "',N'" + kt.HoTen + "','" + kt.CMND + "',N'" + kt.GioiTinh + "',N'" + kt.NgheNghiep + "',N'" + kt.DiaChi + "','" + kt.SDT + "','True','"+ kt.ChuNha +"')";
                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);

                return true;
            }
            catch
            {
                return false;
            }
            //insert into KHACHTRO([MaKT],[MaPT],[HoTen],[CMND],[GioiTinh],[NgeNghiep],[DiaChi],[SDT],[image],[Trangthai]) values ('"+ kt.MaKT +"','"+ kt.MaPT +"','"+ kt.HoTen +"','"+ kt.CMND +"','"+ kt.GioiTinh +"','"+ kt.NgheNghiep +"','"+ kt.DiaChi +"','"+ kt.SDT +"','"+ kt.image +"','True')";
        }
        public static bool UPDATEtrangthaiphong(PHIEUTHUE_DTO pt)
        {
            try
            {
                string sTruyVan = "UPDATE PHONGTRO SET TrangThaiThue= 'True' where MaPT= '"+pt.MaPT+"'";

                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);

                return true;
            }
            catch
            {
                return false;
            }
        }
        

        public static bool DANGKY(PHIEUTHUE_DTO pt)
        {
            try
            {
                string sTruyVan = "insert into QUANLITHUEPHONG([MaKT],[NgayThue],[TrangThai],[TienDatCoc]) VALUES('" + pt.MaKT + "','" + pt.NgayThue + "','True','" + pt.TienDatCoc + "')";

                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UPDATE(KHACHTRO_DTO kt)
        {
            try
            {
                string sTruyVan = "UPDATE KHACHTRO SET HoTen=N'"+ kt.HoTen +"',CMND='"+ kt.CMND +"',GioiTinh=N'"+ kt.GioiTinh +"',NgeNghiep=N'"+ kt.NgheNghiep +"',DiaChi=N'"+ kt.DiaChi +"',SDT='"+ kt.SDT +"'WHERE MaKT='"+ kt.MaKT +"'";

                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
