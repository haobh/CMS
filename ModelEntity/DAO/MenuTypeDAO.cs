using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using System.Data.SqlClient;
using System.Data;

namespace ModelEntity.DAO
{
    public class MenuTypeDAO
    {
        //Sử dụng StoreProcedure using List Code
        public List<MenuType> ListAll()
        {
            string sQuery = "spMenuTypeRecordAll";   //Gans SP
            SqlConnection con = DataProvider.Taoketnoi();  //Goi ket noi
            List<MenuType> dt = new List<MenuType>();     //Gan Group vao List
            SqlCommand cmd = new SqlCommand(sQuery, con);   //Command
            cmd.CommandType = CommandType.StoredProcedure;  //Thuực thi
            SqlDataReader sdr = cmd.ExecuteReader();  //Đọc dữ liệu kiểu in ra nhiều bản ghi trong List
            while (sdr.Read())
            {
                dt.Add(new MenuType());        //Add vào List Group
                dt[dt.Count - 1].ID = long.Parse(sdr["ID"].ToString());  //sdr đọc trong db gán vào dt
                dt[dt.Count - 1].Name = sdr["Name"].ToString();
               
            }
            DataProvider.DongKetNoi(con);
            return dt;
        }
        //---------------------------------------
        //-------(Create)Kiem tra ton tai MenuType
        //Kiem tra hang ton tai chua, Kiểm tra nhận giá trị true hoặc false
        public bool KiemTraMenuTypeTonTai(MenuType entity)
        {
            string sQuery = "spMenuTypeRecordFindName";
            SqlConnection con = DataProvider.Taoketnoi();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DataProvider.DongKetNoi(con);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        //---------------------------------------------
        //Insert MenuType
        //Insert bằng Store
        public long Insert(MenuType entity)
        {
            //string sPassEncode = MaHoa(grDTO.Tengroup, grDTO.Mota); Cần thiết gọi hàm mã hóa
            string sQuery = "spMenuTypeInsert";  //Goi Store Procedure
            SqlConnection con = DataProvider.Taoketnoi();
            SqlCommand cmd = new SqlCommand(sQuery, con);  //truyen Store Procedure, va con vao
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", entity.Name);     //middle Name
            int ketqua;
            ketqua = cmd.ExecuteNonQuery(); //Tự có, nếu thành công báo là 1
            DataProvider.DongKetNoi(con);
            return ketqua;
        }
        //(Load Edit)Tìm ID của MenuType để Edit(Load View)
        //--Tim ID cua MenuType, Cach nay la truyen ID cua Group vao
        public MenuType ViewDetail(long id) //id tự nhận bên Controller de lay ban ghi Update
        {
            string sQuery = "spMenuTypeRecordFindID";
            SqlConnection con = DataProvider.Taoketnoi();
            MenuType dt = new MenuType();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.CommandType = CommandType.StoredProcedure;  //Thực hi Store
            cmd.Parameters.AddWithValue("@id ", id); //gán id vào Store

            SqlDataReader sdr = cmd.ExecuteReader();  //Đọc dữ liệu kiểu in ra 1 bản ghi
            while (sdr.Read())
            {
                dt.ID = long.Parse(sdr["ID"].ToString());
                dt.Name = sdr["Name"].ToString();                
            }
            DataProvider.DongKetNoi(con);
            return dt;
        }
        //---------------------------------------------
        //Edit MenuType
        //Edit bằng Store
        public long Edit(MenuType entity)
        {
            //string sPassEncode = MaHoa(grDTO.Tengroup, grDTO.Mota); Cần thiết gọi hàm mã hóa
            string sQuery = "spMenuTypeUpdate";  //Goi Store Procedure
            SqlConnection con = DataProvider.Taoketnoi();
            SqlCommand cmd = new SqlCommand(sQuery, con);  //truyen Store Procedure, va con vao
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", entity.ID);
            cmd.Parameters.AddWithValue("@Name", entity.Name);     //middle Name
            int ketqua;
            ketqua = cmd.ExecuteNonQuery(); //Tự có, nếu thành công báo là 1
            DataProvider.DongKetNoi(con);
            return ketqua;
        }
        //---------------------------------------------
        //Delete MenuType
        //Delete bằng Store
        public long Delete(MenuType entity)
        {
            //string sPassEncode = MaHoa(grDTO.Tengroup, grDTO.Mota); Cần thiết gọi hàm mã hóa
            string sQuery = "spMenuTypeDelete";  //Goi Store Procedure
            SqlConnection con = DataProvider.Taoketnoi();
            SqlCommand cmd = new SqlCommand(sQuery, con);  //truyen Store Procedure, va con vao
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", entity.ID);
            int ketqua;
            ketqua = cmd.ExecuteNonQuery(); //Tự có, nếu thành công báo là 1
            DataProvider.DongKetNoi(con);
            return ketqua;
        }
    }
}
