using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using phongtro.FileKetNoiCSDL;
using System.Data;
namespace phongtro.HeThongXuLy
{
    class ThongtindichvuDAO
    {
        static SqlConnection con;
        public static DataTable dodgv()
        {
            string sTruyvan = "select * from DichVu";
            con = DataAccess.KetNoi();

            DataTable dt = DataAccess.LayDataTable(sTruyvan, con);
            DataAccess.DongKetNoi(con);

            return dt;



        }

        public static bool Them(ThongtindichvuDTO dv)
        {
            try
            {
                string sTruyVan = "insert into DichVu( TenDV, DonGia, DonViTinh) values (N'" + dv.STenDV + "', '" + dv.SDonGia + "','" + dv.SDonViTinh + "')";
                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CapNhat(ThongtindichvuDTO dv)
        {
            try
            {
                string sTruyVan = @"update DichVu set TenDV=N'" + dv.STenDV + "', DonGia=N'" + dv.SDonGia + "', DonViTinh=N'" + dv.SDonViTinh + "' where MaDV= '" + dv.SMaDV + "'";
                con = DataAccess.KetNoi();
                DataAccess.ThucThiTruyVanNonQuery(sTruyVan, con);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool Xoa(ThongtindichvuDTO dv)
        {
            try
            {
                string sTruyVan = "delete from DichVu where MaDV= '" + dv.SMaDV + "'";
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


