using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Areas.Admin.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Admin/Module
        public ActionResult Index()
        {
            return View();
        }
    }
}