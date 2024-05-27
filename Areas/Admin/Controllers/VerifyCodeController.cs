﻿using KhoaHocOnline.Models;
using KhoaHocOnline.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KhoaHocOnline.Areas.Admin.Controllers
{
    public class VerifyCodeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/VerifyCode
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<VerifyCode> items = db.VerifyCodes.OrderByDescending(x => x.VerifyCodeID);
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Email.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = db.VerifyCodes.OrderByDescending(x => x.VerifyCodeID).ToPagedList(pageIndex, pageSize);
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
        public ActionResult Add(VerifyCode model)
        {
            if (ModelState.IsValid)
            {
                model.ExpiredTime = DateTime.Today;
                db.VerifyCodes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.VerifyCodes.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VerifyCode model)
        {
            if (ModelState.IsValid)
            {
                model.ExpiredTime = DateTime.Today;
                db.VerifyCodes.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.VerifyCodes.Find(id);
            if (item != null)
            {
                db.VerifyCodes.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

        //[HttpPost]
        //public ActionResult IsActive(int id)
        //{
        //    var item = db.VerifyCodes.Find(id);
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
        public ActionResult DeleteAll(string VerifyCodeIDs)
        {
            if (!string.IsNullOrEmpty(VerifyCodeIDs))
            {
                var items = VerifyCodeIDs.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.VerifyCodes.Find(Convert.ToInt32(item));
                        db.VerifyCodes.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}