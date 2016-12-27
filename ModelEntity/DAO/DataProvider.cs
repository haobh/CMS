using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ModelEntity.DAO
{
    public class DataProvider
    {
        public static SqlConnection Taoketnoi()
        {
            try
            {
                string sConString = System.Configuration.ConfigurationManager.ConnectionStrings["DBContextCMS"].ConnectionString;
                SqlConnection con = new SqlConnection(sConString);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //public static DataTable LayDataTable(string sQuery, SqlConnection con)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public static bool ExecuteNonQuery(string sQuery, SqlConnection con)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void DongKetNoi(SqlConnection con)
        {
            con.Close();//Đóng kết nối
            con.Dispose(); //Hủy đối tượng, giải phóng kết nối
        }
    }
}
