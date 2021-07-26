using ProjectUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUser.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Product_categoryEntities _db = new Product_categoryEntities();
        public ActionResult Index()
        {
            return View(_db.tblUsers.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblUser tb)
        {
            _db.tblUsers.Add(tb);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(tb);
        }
        [HttpPost]
        public ActionResult Edit(tblUser tb)
        {
            tblUser tbl = _db.tblUsers.Where(u => u.UserId == tb.UserId).FirstOrDefault();
            tbl.UserName = tb.UserName;
            tbl.Password = tb.Password;
            tbl.Usertype = tb.Usertype;
            tbl.FullName = tb.FullName;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(tb);
        }
        public ActionResult Delete(int id)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            return View(tb);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete_Delete(int id)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            _db.tblUsers.Remove(tb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}