using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using System.Data.SqlClient;
using System.Data;
using ModelEntity.DAO;

namespace ModelEntity.DAO
{
    public class GroupDAO
    {
        //Sử dụng StoreProcedure using List Code
        public List<Group> ListAll()
        {
            string sQuery = "spGroupRecordAll";   //Gans SP
            SqlConnection con = DataProvider.Taoketnoi();  //Goi ket noi
            List<Group> dt = new List<Group>();     //Gan Group vao List
            SqlCommand cmd = new SqlCommand(sQuery, con);   //Command
            cmd.CommandType = CommandType.StoredProcedure;  //Thuực thi
            SqlDataReader sdr = cmd.ExecuteReader();  //Đọc dữ liệu kiểu in ra nhiều bản ghi trong List
            while (sdr.Read())
            {
                dt.Add(new Group());        //Add vào List Group
                dt[dt.Count - 1].ID = sdr["ID"].ToString();  //sdr đọc trong db gán vào dt
                dt[dt.Count - 1].Name = sdr["Name"].ToString();
                dt[dt.Count - 1].Description = sdr["Description"].ToString();
                dt[dt.Count - 1].CreatedDate = DateTime.Parse(sdr["CreatedDate"].ToString());
                dt[dt.Count - 1].CreatedBy = sdr["CreatedBy"].ToString();
                dt[dt.Count - 1].UpdatedDate = DateTime.Parse(sdr["UpdatedDate"].ToString());
                dt[dt.Count - 1].UpdatedBy = sdr["UpdatedBy"].ToString();
                dt[dt.Count - 1].IsActived = bool.Parse(sdr["IsActived"].ToString());
            }
            DataProvider.DongKetNoi(con);
            return dt;
        }
        //Tìm ID của Group để Edit(Load View)
        //--Tim ID cua Group, Cach nay la truyen ID cua Group vao
        public Group ViewDetail(string id) //id tự nhận bên Controller de lay ban ghi Update
        {
            string sQuery = "spGroupRecordFindID";
            SqlConnection con = DataProvider.Taoketnoi();
            Group dt = new Group();
            SqlCommand cmd = new SqlCommand(sQuery, con);
            cmd.CommandType = CommandType.StoredProcedure;  //Thực hi Store
            cmd.Parameters.AddWithValue("@id ", id); //gán id vào Store

            SqlDataReader sdr = cmd.ExecuteReader();  //Đọc dữ liệu kiểu in ra 1 bản ghi
            while (sdr.Read())
            {
                dt.ID = sdr["ID"].ToString();
                dt.Name = sdr["Name"].ToString();
                dt.Description = sdr["Description"].ToString();
                dt.CreatedDate = DateTime.Parse(sdr["CreatedDate"].ToString());
                dt.CreatedBy = sdr["CreatedBy"].ToString();
                dt.UpdatedDate = DateTime.Parse(sdr["UpdatedDate"].ToString());
                dt.UpdatedBy = sdr["UpdatedBy"].ToString();
                dt.IsActived = bool.Parse(sdr["IsActived"].ToString());
            }
            DataProvider.DongKetNoi(con);
            return dt;
        }
        //---------------------------------------
        //-------Kiem tra ton tai Group
        //Kiem tra hang ton tai chua, Kiểm tra nhận giá trị true hoặc false
        public bool KiemTraGroupTonTai(Group entity)
        {
            string sQuery = "spGroupRecordFindName";
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
        //Insert Group
        //Insert bằng Store
        public long Insert(Group entity)
        {
            //string sPassEncode = MaHoa(grDTO.Tengroup, grDTO.Mota); Cần thiết gọi hàm mã hóa
            string sQuery = "spGroupInsert";  //Goi Store Procedure
            SqlConnection con = DataProvider.Taoketnoi();
            SqlCommand cmd = new SqlCommand(sQuery, con);  //truyen Store Procedure, va con vao
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", entity.ID);        //La ma Group da dc ma hoa
            cmd.Parameters.AddWithValue("@Name", entity.Name);     //middle Name
            cmd.Parameters.AddWithValue("@Description ", entity.Description);
            cmd.Parameters.AddWithValue("@CreatedDate",entity.CreatedDate);
            cmd.Parameters.AddWithValue("@CreatedBy ", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedDate", entity.UpdatedDate);
            cmd.Parameters.AddWithValue("@UpdatedBy ", entity.UpdatedBy);
            cmd.Parameters.AddWithValue("@IsActived", entity.IsActived);
            int ketqua;
            ketqua = cmd.ExecuteNonQuery(); //Tự có, nếu thành công báo là 1
            DataProvider.DongKetNoi(con);
            return ketqua;
        }

    }
}
