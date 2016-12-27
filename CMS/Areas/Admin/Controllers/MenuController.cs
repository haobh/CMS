using ModelEntity.DAO;
using ModelEntity.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            int currPage = int.Parse("0" + Request.QueryString["page"]); //Lấy page truyền vào ở View
            if (currPage == 0) currPage = 1; //Neu currePage la 0 thi hien thi sang 1

            //string searchString=null;
            string searchString = Request.QueryString["searchString"];
            int recordPage = 5;   //Số bản ghi hiển thị trên 1 trang
            int totalRecord = 0;   //khởi tạo tổng số bản ghi là 0
            ViewBag.Total = totalRecord;  //So ban ghi
            ViewBag.Page = currPage;  //Trang hien tai

            //Lấy tổng số bản ghi, và truyền tham số phân trang
            var model = new MenuDAO().ListAll(searchString, ref totalRecord, currPage, recordPage);

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
        //-----------------
        public void SetViewBag(long? selectedID=null)
        {
            var Dao = new MenuDAO();
            ViewBag.ModuleID = new SelectList(Dao.LayDroDownList(), "ID", "Name", selectedID);
        }
        //------------------------------
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Menu entity)
        {           
            bool kiemtra = new MenuDAO().KiemTraMenuTonTai(entity);
            if (kiemtra == true)
            {
                SetAlert("Đã tồn tại trong hệ thống !", "success");
            }
            else
            {
                long id = new MenuDAO().Insert(entity);
                if (id > 0)
                {
                    SetAlert("Tạo mới thành công", "success");
                    return RedirectToAction("Create", "Menu");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công !");
                }
            }
            return View("Create");
        }
        //-----------
        // GET: Admin/Menu
        public ActionResult TreeView()
        {
            var model = new MenuDAO().TreeView();
            return View(model);
        }
        //----
    }
}