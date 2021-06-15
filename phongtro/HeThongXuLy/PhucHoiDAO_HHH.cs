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
    class PhucHoiDAO_HHH
    {
        static SqlConnection con;
        public static bool phuchoi_cuc_bo(PhucHoiDTO_HHH phuchoi)
        {
            try
            {

                string sTruyVan = @"restore database NhaTro from disk= '" + phuchoi.SPhucHoi + "'";
                con = DataAccess.Restore_cuc_bo();
                //Truy vấn không trả về 
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
