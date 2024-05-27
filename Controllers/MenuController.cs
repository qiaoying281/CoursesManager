using KhoaHocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuCourseType ()
        {
            var items = db.CourseTypes.ToList();
            return PartialView ("_MenuCourseType",items);
        }

        public ActionResult CourseTypeArrivals()
        {
            var items = db.CourseTypes.ToList();
            return PartialView("_CourseTypeArrivals", items);
        }
    }
}