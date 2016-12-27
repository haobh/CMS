using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.DAO;
using ModelEntity.EF;

namespace CMS.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var model = new MenuTypeDAO().ListAll();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MenuType entity)
        {
            bool kiemtra = new MenuTypeDAO().KiemTraMenuTypeTonTai(entity);
            if (kiemtra == true)
            {
                SetAlert("Đã tồn tại trong hệ thống !", "success");
            }
            else
            {
                long id = new MenuTypeDAO().Insert(entity);
                if (id > 0)
                {
                    SetAlert("Tạo mới thành công", "success");
                    return RedirectToAction("Create", "MenuType");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công !");
                }
            }
            return View("Create");
        }
        //-----------------
        public ActionResult Edit(long id)
        {
            var entity = new MenuTypeDAO().ViewDetail(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Edit(MenuType entity)
        {
            bool kiemtra = new MenuTypeDAO().KiemTraMenuTypeTonTai(entity);
            if (kiemtra == true)
            {
                SetAlert("Đã tồn tại trong hệ thống !", "success");
            }
            else
            {
                long id = new MenuTypeDAO().Edit(entity);
                if (id > 0)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Edit", "MenuType");//Action: Index, Controller: User neu OK
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công !");
                }
            }
            return View("Edit");
        }
        //Delete
        public ActionResult Delete(long id)
        {
            var entity = new MenuTypeDAO().ViewDetail(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Delete(MenuType entity)
        {
            long id = new MenuTypeDAO().Delete(entity);
            if (id > 0)
            {
                SetAlert("Xóa bản ghi thành công", "success");
                return RedirectToAction("Index", "MenuType");//Action: Index, Controller: User neu OK
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công !");
            }

            return View("Index");
        }
    }
}