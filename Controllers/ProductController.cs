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
            
                fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                tb.Photo = fup.FileName;
            }
            _db.tblProducts.Add(tb);
            _db.SaveChanges();
            ViewBag.Message = "Product Created";
            ViewBag.Categories = _db.tblCategories.ToList();

            return View();
        }
        public ActionResult Edit(int id)
        {
            var products=_db.tblProducts.Where(p=>p.ProductId==id).FirstOrDefault();
            ProductViewModel pvm = new ProductViewModel();
            pvm.ProductId = products.ProductId;
            pvm.CategoryId = products.CategoryId;
            pvm.ProductName = products.ProductName;
            pvm.UnitPrice = products.UnitPrice;
            pvm.SellingPrice = products.SellingPrice;
            pvm.Photo = products.Photo;
            _db.SaveChanges();

            ViewBag.Categories = _db.tblCategories.ToList();
            return View(pvm);
                
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel pvm)
        {
            var products = _db.tblProducts.Where(p => p.ProductId == pvm.ProductId).FirstOrDefault();
            products.CategoryId = pvm.CategoryId;
            products.ProductName = pvm.ProductName;
            products.SellingPrice = pvm.SellingPrice;
            products.UnitPrice = pvm.UnitPrice;
            HttpPostedFileBase fup = Request.Files["Photo"];
            if (fup != null)
            {
                if (fup.FileName != "")
                {
                    System.IO.File.Delete(Server.MapPath("~/ProductImages/" + fup.FileName));
                    products.Photo = fup.FileName;
                    fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                } 
            }
            _db.SaveChanges();

            ViewBag.Categories = _db.tblCategories.ToList();
            return RedirectToAction("ManageProduct");
            
        }
    }
}