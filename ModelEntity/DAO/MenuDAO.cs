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
    public class MenuDAO
    {
        //Khoi tao Contructor
        DBContextCMS db = null;
        public MenuDAO()
        {
            db = new DBContextCMS(); //Khoi tao DB
        }
        //Sử dụng StoreProcedure using List Code
        public List<Menu> ListAll(string searchString, ref int totalRecord, int currPage, int recodperpage)
        {
            totalRecord = db.Menus.Count();
            if (string.IsNullOrEmpty(searchString)) //Nếu searString mà Null hoặc Empty
            {
                searchString = "";   //Set cho nó có ký tự                 
            }
            string sQuery = "spPhanTrangMenuAll";   //Gans SP
            SqlConnection con = DataProvider.Taoketnoi();  //Goi ket noi
            List<Menu> dt = new List<Menu>();     //Gan Group vao List
            SqlCommand cmd = new SqlCommand(sQuery, con);   //Command
            cmd.CommandType = CommandType.StoredProcedure;  //Thuực thi
            cmd.Parameters.AddWithValue("@searchString ", searchString);
            cmd.Parameters.AddWithValue("@currPage ", currPage);
            cmd.Parameters.AddWithValue("@recodperpage", recodperpage);
            SqlDataReader sdr = cmd.ExecuteReader();  //Đọc dữ liệu kiểu in ra nhiều bản ghi trong List
            while (sdr.Read())
            {
                dt.Add(new Menu());        //Add vào List Group
                dt[dt.Count - 1].ID = long.Parse(sdr["ID"].ToString());  //sdr đọc trong db gán vào dt
                dt[dt.Count - 1].Text = sdr["Text"].ToString();
                dt[dt.Count - 1].Link = sdr["Link"].ToString();
                dt[dt.Count - 1].DisplayOrder = int.Parse(sdr["DisplayOrder"].ToString());
                dt[dt.Count - 1].Target = sdr["Target"].ToString();
                dt[dt.Count - 1].Status = bool.Parse(sdr["Status"].ToString());
                dt[dt.Count - 1].ParentMenuID = int.Parse(sdr["ParentMenuID"].ToString());
                dt[dt.Count - 1].TypeID = long.Parse(sdr["TypeID"].ToString());
                dt[dt.Count - 1].ModuleID = sdr["ModuleID"].ToString();

            }
            DataProvider.DongKetNoi(con);
            return dt;
        }
        //-----------------
        public List<Menu> TreeView()
        {
            return db.Menus.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList();
        }
        //---------------------------------------
        //-------Kiem tra ton tai Menu
        //Kiem tra hang ton tai chua, Kiểm tra nhận giá trị true hoặc false
        public bool KiemTraMenuTonTai(Menu entity)
        {
            var name=db.Menus.Where(x=>x.Text==entity.Text).Count(); //Trả tên Menu nếu có trong bảng Menu ra ben ngoai
            if (name > 0)
            {
                return true;
            }
            return false;
        }
        //----------------
        //Insert
        public long Insert(Menu entity)
        {
            db.Menus.Add(entity); //Users la bang da dc EF gen ra trong EF, Goi phuong thuc Add entity User gan vao Users
            db.SaveChanges(); //Sau do luu lai
            return entity.ID; //Tra ket qua 1 ra ben ngoai neu OK
        }
        //--------------------------
        public List<Module> LayDroDownList()
        {
            return db.Modules.Where(x=>x.Status==true).ToList();          
        }
    }
}
