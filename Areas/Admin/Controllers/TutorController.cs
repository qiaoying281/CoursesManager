using KhoaHocOnline.Models;
using KhoaHocOnline.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Areas.Admin.Controllers
{
    public class TutorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Tutor
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Tutor> items = db.Tutors.OrderByDescending(x => x.TutorID);
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.FullName.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = db.Tutors.OrderByDescending(x => x.TutorID).ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Tutor model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                db.Tutors.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Tutors.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tutor model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedAt = DateTime.Now;
                db.Tutors.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Tutors.Find(id);
            if (item != null)
            {
                db.Tutors.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

        //[HttpPost]
        //public ActionResult IsActive(int id)
        //{
        //    var item = db.Tutors.Find(id);
        //    if (item != null)
        //    {
        //        item.IsActive = !item.IsActive;
        //        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return Json(new { success = true, isActive = item.IsActive });
        //    }
        //    return Json(new { success = false });
        //}

        [HttpPost]
        public ActionResult DeleteAll(string TutorIDs)
        {
            if (!string.IsNullOrEmpty(TutorIDs))
            {
                var items = TutorIDs.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Tutors.Find(Convert.ToInt32(item));
                        db.Tutors.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}