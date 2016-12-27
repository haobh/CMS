using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.DAO;
using ModelEntity.EF;

namespace CMS.Areas.Admin.Controllers
{
    public class GroupController : BaseController
    {
        // GET: Admin/Group
        public ActionResult Index()
        {
            var model = new GroupDAO().ListAll();
            return View(model);
        }
        //----------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //------------------------------------
        [HttpPost]
        public ActionResult Create(Group entity)
        {
            bool kiemtra = new GroupDAO().KiemTraGroupTonTai(entity);
            if (kiemtra == true)
            {
                SetAlert("Đã tồn tại nhóm trong hệ thống !","success");
            }
            else
            {
                long id = new GroupDAO().Insert(entity);
                if (id > 0)
                {
                    SetAlert("Tạo mới thành công", "success");
                    return RedirectToAction("Create", "Group");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhóm không thành công !");
                }
            }
            return View("Create");
        }
        //------------------------------------
        [HttpGet]
        public ActionResult Edit(string id) //id tự động nhận ở URL của View, dựa vào Route
        {
            var group = new GroupDAO().ViewDetail(id);
            return View(group);
        }
    }
}