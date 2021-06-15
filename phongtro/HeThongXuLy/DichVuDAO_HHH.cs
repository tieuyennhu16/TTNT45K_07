using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using phongtro.FileKetNoiCSDL;

namespace phongtro.HeThongXuLy
{
    class DichVuDAO_HHH
    {
        static SqlConnection con;
        public static DataTable Load_Combobox()
        {
            string sTruyVan = "select *from PHONGTRO where TrangThaiThue= 'True'";
            //Mở kết nối
            con = DataAccess.KetNoi();
            //Truy xuất vào CSDL để lấy về kết quả đổ vào đối tượng datatable
            DataTable dt = DataAccess.LayDataTable(sTruyVan, con);
            //Đóng kết nối
            DataAccess.DongKetNoi(con);
            return dt;
        }

    }
}
