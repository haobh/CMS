using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntity.EF;
using ModelEntity.ViewModel;
using System.Data.SqlClient;

namespace ModelEntity.DAO
{
    public class ModuleMenuDAO
    {
        /// <summary>
        /// Khoi tao Contructor
        /// </summary>
        DBContextCMS db = null;
        public ModuleMenuDAO()
        {
            db = new DBContextCMS();
        }
        //Dùng LINQ to Entity
        //public IEnumerable<ModuleMenu> ListAll()
        //{
        //    var model = from a in db.Modules     //a la bí danh, Products là bảng ánh xạ trong CSDL
        //                join b in db.Menus  // Join với bảng b, có thể Join được nhiều bảng
        //                //join c in db.Orders
        //                on a.ID equals b.ModuleID   //Giống Iner Join, khoa chính nối khóa ngoại
        //                where a.Status==true
        //                select new ViewModel.ModuleMenu()   //Sau khi noi 2 bang tren, gan thuoc tinh vao bang tam thoi nay
        //                {
        //                    ID = a.ID,  //Chọn những phần tử cần lấy,ID
        //                    ModuleID = b.ModuleID,          //ID cha
        //                    Name = a.Name,
        //                    Text = b.Text, 
        //                    //DisplayOrder=(int)Convert.ToInt32(a.DisplayOrder),                      
        //                    Link = b.Link,
        //                    ParentMenuID=(long)b.ParentMenuID
        //                };
        //    //Nối thêm phần cấu lệnh Select trên
        //    model.OrderByDescending(x => x.DisplayOrder);
        //    return model.ToList();
        //}
        public List<Menu> ListAll()
        {
            return db.Menus.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
