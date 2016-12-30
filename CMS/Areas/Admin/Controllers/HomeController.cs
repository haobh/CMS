using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.DAO;
using ModelEntity.EF;

namespace CMS.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult GetMenu()
        {
            var model = new ModuleMenuDAO().ListAll();
            return PartialView("~/Areas/Admin/Views/Shared/_leftmenu.cshtml", model);
        }
    }
}