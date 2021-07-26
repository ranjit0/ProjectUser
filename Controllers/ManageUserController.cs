using ProjectUser.Models;
using ProjectUser.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUser.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        Product_categoryEntities _db = new Product_categoryEntities();

        public ActionResult Index()
        {
            List<UserViewModel> lstvm = new List<UserViewModel>();
            var users = _db.tblUsers.ToList();
            foreach (var item in users)
            {
                lstvm.Add(new UserViewModel() { UserId = item.UserId, UserName = item.UserName, Password = item.Password, 
                    Usertype = item.Usertype, FullName = item.FullName });

            }
            return View(lstvm);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel uv)
        {
            if (ModelState.IsValid)
            {
                tblUser tb = new tblUser();
                tb.UserName = uv.UserName;
                tb.Password = uv.Password;
                tb.Usertype = uv.Usertype;
                tb.FullName = uv.FullName;
                _db.tblUsers.Add(tb);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == id).FirstOrDefault();
            UserViewModel uv = new UserViewModel();
            uv.UserId = tb.UserId;
            uv.UserName = tb.UserName;
            uv.Usertype = tb.Usertype;
            uv.FullName = tb.FullName;
            uv.Password = tb.Password;
            return View(uv);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel uv)
        {
            tblUser tb = _db.tblUsers.Where(u => u.UserId == uv.UserId).FirstOrDefault();
            tb.UserName = uv.UserName;
            tb.Usertype = uv.Usertype;
            tb.FullName = uv.FullName;
            tb.Password = uv.Password;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}