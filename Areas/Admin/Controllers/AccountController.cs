using KhoaHocOnline.Models;
using KhoaHocOnline.Models.EF;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace KhoaHocOnline.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Account
        public ActionResult Index(string searchText,int? page)
        {
            var pageSize = 5;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<Account> items = db.Accounts.OrderByDescending(x => x.AccountID);
            if(!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Email.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = db.Accounts.OrderByDescending(x=>x.AccountID).ToPagedList(pageIndex,pageSize);
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
        public ActionResult Add(Account model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                model.ResetPasswordTokenExpiry = DateTime.Now;
                db.Accounts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Accounts.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account model)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Attach(model);
                model.UpdatedAt = DateTime.Now;
                db.Entry(model).Property(x => x.Email).IsModified = true;
                db.Entry(model).Property(x => x.Avatar).IsModified = true;
                db.Entry(model).Property(x => x.Password).IsModified = true;
                db.Entry(model).Property(x => x.Status).IsModified = true;
                db.Entry(model).Property(x => x.DecentralizationID).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Accounts.Find(id);
            if(item != null)
            {
                db.Accounts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false});
        }

        [HttpPost]
        public ActionResult DeleteAll(string CourseIDs)
        {
            if (!string.IsNullOrEmpty(CourseIDs))
            {
                var items = CourseIDs.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Courses.Find(Convert.ToInt32(item));
                        db.Courses.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}