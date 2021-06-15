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
    class SaoLuuDuLieuDAO_HHH
    {
        static SqlConnection con;
        public static DataTable Saoluu(SaoLuuDuLieuDTO_HHH sl)
        {
            string sTruyVan = @"backup database NhaTro to disk= '" + sl.STenTep + "'";
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }
    }
}
