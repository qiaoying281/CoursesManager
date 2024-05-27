using KhoaHocOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_ItemsByType(int CourseType)
        {
            var items = db.Courses.Where(x => x.CourseTypeID == CourseType).ToList();
            return PartialView(items);
        }
    }
}