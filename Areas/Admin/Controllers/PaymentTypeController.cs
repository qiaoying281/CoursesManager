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
    public class PaymentTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/PaymentType
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<PaymentType> items = db.PaymentTypes.OrderByDescending(x => x.PaymentTypeID);
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.PaymentTypeName.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = db.PaymentTypes.OrderByDescending(x => x.PaymentTypeID).ToPagedList(pageIndex, pageSize);
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
        public ActionResult Add(PaymentType model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                db.PaymentTypes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.PaymentTypes.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaymentType model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedAt = DateTime.Now;
                db.PaymentTypes.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.PaymentTypes.Find(id);
            if (item != null)
            {
                db.PaymentTypes.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

        //[HttpPost]
        //public ActionResult IsActive(int id)
        //{
        //    var item = db.PaymentTypes.Find(id);
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
        public ActionResult DeleteAll(string PaymentTypeIDs)
        {
            if (!string.IsNullOrEmpty(PaymentTypeIDs))
            {
                var items = PaymentTypeIDs.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.PaymentTypes.Find(Convert.ToInt32(item));
                        db.PaymentTypes.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}