using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.DAO;
using PagedList;
using ModelEntity.EF;
using CMS.Commons;

namespace CMS.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            int currPage = int.Parse("0" + Request.QueryString["page"]); //Lấy page truyền vào ở View
            if (currPage == 0) currPage = 1; //Neu currePage la 0 thi hien thi sang 1

            //string searchString=null;
            string searchString = Request.QueryString["searchString"];
            int recordPage = 10;   //Số bản ghi hiển thị trên 1 trang
            int totalRecord = 0;   //khởi tạo tổng số bản ghi là 0
            ViewBag.Total = totalRecord;  //So ban ghi
            ViewBag.Page = currPage;  //Trang hien tai

            //Lấy tổng số bản ghi, và truyền tham số phân trang
            var model = new UserDAO().ListAll(searchString, ref totalRecord, currPage, recordPage);
            int maxPage = 5;
            int toTalPage = 0; //Khởi tạo tổng số trang

            toTalPage = (int)Math.Ceiling((double)(totalRecord / recordPage)) + 1; //tong so trang = tong so ban ghi / so ban ghi hien thi, 16/5, neu du + 1 trang

            ViewBag.SearchString = searchString;
            //Gans sang ViewBag để hiển thị bên View
            ViewBag.TotalPage = toTalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = toTalPage;
            ViewBag.Next = currPage + 1;
            ViewBag.Prev = currPage - 1;

            return View(model);
        }
        //---------
        //Tạo mới Load View
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] //Dung khi Post du lieu tu Form len
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDAO();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);//Goi ham ma hoa MD5 ben Common ma hoa Password
                user.PassWord = encryptedMd5Pas; //Gan ma hoa Password

                long id = userDao.Insert(user);//Goi ham Insert lop UserDAO
                if (id > 0)
                {
                    SetAlert("Tạo mới thành công", "success");
                    return RedirectToAction("Create", "User");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Them User khong thanh cong !");
                }
            }
            return View("Index");
        }
        //-----------------------------------------
        //Load thông tin tài khoản lên bằng ID truyền vào
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }
        [HttpPost] //Dung khi Post du lieu tu Form len
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var userDao = new UserDAO();
                if (!string.IsNullOrEmpty(user.PassWord)) //Kiem tra o nhap Password ma khong rong thi moi ma hoa
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);//Goi ham ma hoa MD5 ben Common ma hoa Password
                    user.PassWord = encryptedMd5Pas; //Gan ma hoa Password
                }
                var result = userDao.Update(user);//Goi ham Insert lop UserDAO
                if (result)
                {
                    //Response.Write("<script language='JavaScript'> alert('Updated sucessfully !!'); </script>");
                    SetAlert("Chỉnh sửa User thành công", "success");
                    return RedirectToAction("Index", "User");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản không thành công !");
                }
            }
            return View("Index");
        }
        //-----Xoa ban ghi, Nhận ID từ URL
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //new UserDAO.Delete(id); co the viet nhu vay
            var userDao = new UserDAO();
            userDao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}