using ProjectUser.Models;
using ProjectUser.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectUser.Controllers
{
    public class AcountController : Controller
    {
        // GET: Acount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm, string ReturnUrl="")
        {
            using (Product_categoryEntities _db=new Product_categoryEntities())
            {
                var users = _db.tblUsers.Where(u => u.UserName == lvm.UserName && u.Password == lvm.Password).FirstOrDefault();
                if (users != null)
                {
                    FormsAuthentication.SetAuthCookie(lvm.UserName, lvm.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("MyProfile", "Home");
                    }
                }
                else {

                    ModelState.AddModelError("","Invalid User");
                }

            }
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}