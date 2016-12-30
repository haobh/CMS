using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using System.Data.SqlClient;

namespace ModelEntity.DAO
{
    public class UserDAO
    {
        //Khoi tao Contructor
        DBContextCMS db = null;
        public UserDAO()
        {
            db = new DBContextCMS(); //Khoi tao DB
        }
        //-----------------------------
        //Dùng LINQ to Entity
        /*public List<User> ListAll()
        {
            return db.Users.ToList();
        }*/
        //----------------------------------
        //Lay danh sách User bằng Store Procedure
        public List<User> ListAll(string searchString, ref int totalRecord, int currPage, int recodperpage)
        {
            try
            {
                //searchString = "a";                 
                //searchString =searchString.Trim().ToString();
                totalRecord = db.Users.Count();
                if (string.IsNullOrEmpty(searchString)) //Nếu searString mà Null hoặc Empty
                {
                    searchString = "";   //Set cho nó có ký tự                 
                }
                var parameter = new SqlParameter[] //Sử dụng LINQ thì sử dụng mảng để nhận tham số truyền vào
                    {
                        new SqlParameter("@searchString",searchString ??(object)DBNull.Value),
                        new SqlParameter("@currPage",currPage),
                        new SqlParameter("@recodperpage",recodperpage),
                    };
                var list = db.Database.SqlQuery<User>("spPhanTrangUser1 @searchString,@currPage,@recodperpage", parameter).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //---------------------------------------
        //Insert bằng LINQ to Entities
        public long Insert(User entity)
        {
            db.Users.Add(entity); //Users la bang da dc EF gen ra trong EF, Goi phuong thuc Add entity User gan vao Users
            db.SaveChanges(); //Sau do luu lai
            return entity.ID; //Tra ket qua 1 ra ben ngoai neu OK
        }
        //----------------------------------------
        //(Load Edit)Tìm ID của User để Edit(Load View)
        //--Tim ID cua User, Cach nay la truyen ID cua User vao
        public User ViewDetail(int id) //Truyen id de lay ban ghi Update
        {
            return db.Users.Find(id); //Tra id cua User ra ben ngoai
        }
        //------------------------------------------
        //Update
        //----Update 
        public bool Update(User entity)  //Khoi tao Bang User; Users la bang anh xa bang User
        {
            try
            {
                var user = db.Users.Find(entity.ID);//Tim ID cua ban ghi can Update
                user.Name = entity.Name; //user.Name la(Users) EF da gen; entity.Name la CSDL
                if (!string.IsNullOrEmpty(entity.PassWord)) //Kiem tra neu o Nhap Password ma khong rong thi moi gan du lieu
                {
                    user.PassWord = entity.PassWord;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.CreatedBy = entity.CreatedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();  //Luu thong tin sau khi Update
                return true;
            }
            catch (Exception ex)
            {
                //Ghi Log o day
                return false;
            }
        }
        //Xóa bản ghi, nhận vào la ID
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id); //1. Tìm bản ghi
                db.Users.Remove(user); //2. Xóa bản ghi
                db.SaveChanges(); //3. Lưu thông tin
                return true;
            }
            catch (Exception)
            {
                //Log4e: ex o day
                return false;
            }

        }

    }
}
