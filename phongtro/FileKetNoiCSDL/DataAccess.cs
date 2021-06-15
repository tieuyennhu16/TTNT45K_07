using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phongtro.HeThongXuLy;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace phongtro.FileKetNoiCSDL
{
    class DataAccess
    {
        public static SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data Source=.;Initial Catalog=NhaTro;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();
            return con;
        }



        public static SqlConnection Restore_cuc_bo()
        {
            StreamReader doc = File.OpenText(@"C:\\User\\A\\B\\C\\D\\E\\F\\G\\H\\L\\K\\N\\P\\Q\\X\\Y\\Z\\User\Restore_cuc_bo.txt");
            string s = doc.ReadToEnd();
            string sChuoiKetNoi = s;
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();
            return con;
        }

        //Đóng kết nối
        public static void DongKetNoi(SqlConnection con)
        {
            con.Close();
        }


        //Lấy DataTable
        public static DataTable LayDataTable(string sTruyVan, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sTruyVan, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Xóa, cập nhật, thêm...
        //Thực thi truy vấn ExcuteNonQuery
        public static void ThucThiTruyVanNonQuery(string sTruyVan, SqlConnection con)
        {
            SqlCommand com = new SqlCommand(sTruyVan, con);
            com.ExecuteNonQuery();
        }
    }
}
