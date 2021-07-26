using ProjectUser.Models;
using ProjectUser.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUser.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Product_categoryEntities _db = new Product_categoryEntities();

        public ActionResult ManageProduct()
        {
            List<ProductViewModel> lpvm = new List<ProductViewModel>();
            var products = _db.tblProducts.ToList();
            foreach (var item in products)
            {
                lpvm.Add(new ProductViewModel() { ProductId=item.ProductId,CategoryName=item.
                    tblCategory.CategoryName,ProductName=item.ProductName,UnitPrice=item
                    .UnitPrice,SellingPrice=item.SellingPrice,Photo=item.Photo});
            }
            return View(lpvm);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _db.tblCategories.ToList();
            return View();

        }
        [HttpPost]
        public ActionResult Create(ProductViewModel pvm)
        {
            tblProduct tb = new tblProduct();
            tb.CategoryId = pvm.CategoryId;
            tb.ProductName = pvm.ProductName;
            tb.UnitPrice = pvm.UnitPrice;
            tb.SellingPrice = pvm.SellingPrice;
            HttpPostedFileBase fup = Request.Files["Photo"];
            if (fup != null)
            {
                tb.Photo = fup.FileName;
                fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
            }
            _db.tblProducts.Add(tb);
            _db.SaveChanges();
            ViewBag.Message = "Product Created";
            ViewBag.Categories = _db.tblCategories.ToList();

            return View();
        }
    }
}