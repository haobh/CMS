using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEntity.DAO;
using ModelEntity.EF;

namespace CMS.Areas.Admin.Controllers
{
    public class ModuleController : BaseController
    {
        // GET: Admin/Module
        public ActionResult Index()
        {
            var model = new ModuleDAO().ListAll();
            return View(model);
        }
    }
}