using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using phongtro.FileKetNoiCSDL;

namespace phongtro.HeThongXuLy
{
    class DangNhapDAO
    {
        static SqlConnection con;
        public static bool Kiemtranguoidung(DangNhapDTO dn)
        {
            string sTruyvan = "select MaND , MatKhau  from CHUNHA where MaND = '" + dn .SMaND +"' and MatKhau ='"+dn.SMatKhau +"'";
            con = DataAccess.KetNoi();

            DataTable dt = DataAccess.LayDataTable(sTruyvan, con);
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
        public static bool Kiemtranguothan(DangNhapDTO dn)
        {
            string sTruyvan = "select MaNN , MK  from NGUOINHA where MaNN = '" + dn.SMaNN + "' and MK ='" + dn.SMK + "'";
            con = DataAccess.KetNoi();

            DataTable dt = DataAccess.LayDataTable(sTruyvan, con);
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
    }
}
