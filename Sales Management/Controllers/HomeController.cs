using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sales_Management.Data.Models;
using Sales_Management.Data.ViewModels;
using Sales_Management.Data;
using Sales_Management.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Sales_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostEnvironment;

        public HomeController(AppDbContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index(int? id)
        {
            var ctx = _context;

            var categoryWiseProductQty = from p in ctx.Products
                                         group p by p.CategoryId into g
                                         select new
                                         {
                                             g.FirstOrDefault().CategoryId,
                                             Qty = g.Sum(s => s.Quantity)
                                         };
            var listCategory = (from c in ctx.Categories
                                join cwpq in categoryWiseProductQty on c.CategoryId equals cwpq.CategoryId
                                select new VmCategory
                                {
                                    CategoryName = c.CategoryName,
                                    CategoryId = cwpq.CategoryId,
                                    Quantity = cwpq.Qty
                                }).ToList();
            var listProduct = (from p in ctx.Products
                               join c in ctx.Categories on p.CategoryId equals c.CategoryId
                               where p.CategoryId == id
                               select new VmProduct
                               {
                                   CategoryId = p.CategoryId,
                                   CategoryName = c.CategoryName,
                                   ExpireDate = p.ExpireDate,
                                   ImagePath = p.ImagePath,
                                   Price = p.Price,
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   Quantity = p.Quantity
                               }).ToList();

            var oCategoryWiseProduct = new VmCategoryWiseProduct();
            oCategoryWiseProduct.CategoryList = listCategory;
            oCategoryWiseProduct.ProductList = listProduct;
            oCategoryWiseProduct.CategoryId = listProduct.Count > 0 ? listProduct[0].CategoryId : 0;
            oCategoryWiseProduct.CategoryName = listProduct.Count > 0 ? listProduct[0].CategoryName : "";

            return View(oCategoryWiseProduct);
        }

        public IActionResult Create()
        {
            var model = new VmProductCategory();
            var ctx = _context;
            model.CategoryList = ctx.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model, string[] ProductName, decimal[] Price, int[] Quantity, DateTime[] ExpireDate, IFormFile[] imgFile)
        {
            var ctx = _context;
            var oCatetory = (from c in ctx.Categories where c.CategoryName == model.CategoryName.Trim() select c).FirstOrDefault();
            if (oCatetory == null)
            {
                ctx.Categories.Add(model);
                ctx.SaveChanges();
            }
            else
            {
                model.CategoryId = oCatetory.CategoryId;
            }

            var listProduct = new List<Product>();
            for (int i = 0; i < ProductName.Length; i++)
            {
                string imgPath = "";
                if (imgFile[i] != null && imgFile[i].Length > 0)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var fileName = Path.GetFileName(imgFile[i].FileName);
                    string path = Path.Combine(wwwRootPath + "/uploads/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await imgFile[i].CopyToAsync(fileStream);
                    }

                    imgPath = "/uploads/" + imgFile[i].FileName;
                }

                var newProduct = new Product();
                newProduct.ProductName = ProductName[i];
                newProduct.Quantity = Quantity[i];
                newProduct.Price = Price[i];
                newProduct.ExpireDate = ExpireDate[i];
                newProduct.ImagePath = imgPath;
                newProduct.Quantity = Quantity[i];
                newProduct.CategoryId = model.CategoryId;
                listProduct.Add(newProduct);
            }
            ctx.Products.AddRange(listProduct);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var ctx = _context;
            var oProduct = (from p in ctx.Products
                            join c in ctx.Categories on p.CategoryId equals c.CategoryId
                            where p.ProductId == id
                            select new VmProduct
                            {
                                CategoryId = p.CategoryId,
                                CategoryName = c.CategoryName,
                                ExpireDate = p.ExpireDate,
                                ImagePath = p.ImagePath,
                                Price = p.Price,
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                Quantity = p.Quantity
                            }).FirstOrDefault();
            oProduct.CategoryList = ctx.Categories.ToList(); // for showing category list in view
            return View(oProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VmProduct model)
        {
            var ctx = _context;

            string imgPath = "";
            if (model.ImgFile != null && model.ImgFile.Length > 0)
            {
                //var fileName = Path.GetFileName(model.ImgFile.FileName);
                //string fileLocation = Path.Combine(
                //    Server.MapPath("~/uploads"), fileName);
                //model.ImgFile.SaveAs(fileLocation);
                string wwwRootPath = _hostEnvironment.WebRootPath;
                var fileName = Path.GetFileName(model.ImgFile.FileName);
                string path = Path.Combine(wwwRootPath + "/uploads/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ImgFile.CopyToAsync(fileStream);
                }

                imgPath = "/uploads/" + model.ImgFile.FileName;
            }

            var oProduct = ctx.Products.Where(w => w.ProductId == model.ProductId).FirstOrDefault();
            if (oProduct != null)
            {
                oProduct.ProductName = model.ProductName;
                oProduct.Quantity = model.Quantity;
                oProduct.Price = model.Price;
                oProduct.ExpireDate = model.ExpireDate;
                oProduct.CategoryId = model.CategoryId;
                if (!string.IsNullOrEmpty(imgPath))
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var fileName = Path.GetFileName(oProduct.ImagePath);
                    string fileLocation = Path.Combine(wwwRootPath + "/uploads/", fileName);
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }
                }
                oProduct.ImagePath = imgPath == "" ? oProduct.ImagePath : imgPath;

                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditMultiple(int id)
        {
            var ctx = _context;
            var oCategoryWiseProduct = new VmCategoryWiseProduct();
            var listProduct = (from p in ctx.Products
                               join c in ctx.Categories on p.CategoryId equals c.CategoryId
                               where p.CategoryId == id
                               select new VmProduct
                               {
                                   CategoryId = p.CategoryId,
                                   CategoryName = c.CategoryName,
                                   ExpireDate = p.ExpireDate,
                                   ImagePath = p.ImagePath,
                                   Price = p.Price,
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   Quantity = p.Quantity
                               }).ToList();
            oCategoryWiseProduct.ProductList = listProduct;
            // for showing category list in view
            oCategoryWiseProduct.CategoryList = (from c in ctx.Categories
                                                 select new VmCategory
                                                 {
                                                     CategoryId = c.CategoryId,
                                                     CategoryName = c.CategoryName
                                                 }).ToList();
            oCategoryWiseProduct.CategoryId = listProduct.Count > 0 ? listProduct[0].CategoryId : 0;
            oCategoryWiseProduct.CategoryName = listProduct.Count > 0 ? listProduct[0].CategoryName : "";
            return View(oCategoryWiseProduct);
        }

        [HttpPost]
        public async Task<IActionResult> EditMultiple(Category model, int[] ProductId, string[] ProductName, decimal[] Price, int[] Quantity, DateTime[] ExpireDate, IFormFile[] imgFile)
        {
            var ctx = _context;
            var listProduct = new List<Product>();
            for (int i = 0; i < ProductName.Length; i++)
            {
                if (ProductId[i] > 0)
                {
                    string imgPath = "";
                    if (imgFile[i] != null && imgFile[i].Length > 0)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        var fileName = Path.GetFileName(imgFile[i].FileName);
                        string fileLocation = Path.Combine(wwwRootPath + "/uploads/", fileName);
                        using (var fileStream = new FileStream(fileLocation, FileMode.Create))
                        {
                            await imgFile[i].CopyToAsync(fileStream);
                        }

                        imgPath = "/uploads/" + imgFile[i].FileName;
                    }
                    int pid = ProductId[i];
                    var oProduct = ctx.Products.Where(w => w.ProductId == pid).FirstOrDefault();
                    if (oProduct != null)
                    {
                        oProduct.ProductName = ProductName[i];
                        oProduct.Quantity = Quantity[i];
                        oProduct.Price = Price[i];
                        oProduct.ExpireDate = ExpireDate[i];
                        oProduct.CategoryId = model.CategoryId;
                        if (!string.IsNullOrEmpty(imgPath))
                        {
                            string wwwRootPath = _hostEnvironment.WebRootPath;
                            var fileName = Path.GetFileName(oProduct.ImagePath);
                            string fileLocation = Path.Combine(wwwRootPath + "/uploads/", fileName);
                            if (System.IO.File.Exists(fileLocation))
                            {
                                System.IO.File.Delete(fileLocation);
                            }
                        }
                        oProduct.ImagePath = imgPath == "" ? oProduct.ImagePath : imgPath;
                        ctx.SaveChanges();
                    }
                }
                else if (!string.IsNullOrEmpty(ProductName[i]))
                {
                    string imgPath = "";
                    if (imgFile[i] != null && imgFile[i].Length > 0)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        var fileName = Path.GetFileName(imgFile[i].FileName);
                        string fileLocation = Path.Combine(wwwRootPath + "/uploads/", fileName);
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        imgPath = "/uploads/" + imgFile[i].FileName;
                    }

                    var newProduct = new Product();
                    newProduct.ProductName = ProductName[i];
                    newProduct.Quantity = Quantity[i];
                    newProduct.Price = Price[i];
                    newProduct.ExpireDate = ExpireDate[i];
                    newProduct.ImagePath = imgPath;
                    newProduct.Quantity = Quantity[i];
                    newProduct.CategoryId = model.CategoryId;
                    ctx.Products.Add(newProduct);
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var ctx = _context;
            var oProduct = ctx.Products.Where(p => p.ProductId == id).FirstOrDefault();
            if (oProduct != null)
            {
                ctx.Products.Remove(oProduct);
                ctx.SaveChanges();

                string wwwRootPath = _hostEnvironment.WebRootPath;
                var fileName = Path.GetFileName(oProduct.ImagePath);
                string path = Path.Combine(wwwRootPath + "/uploads/", fileName);
                // Check if file exists with its full path    
                if (System.IO.File.Exists(path))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(path);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteMultiple(int id)
        {
            var ctx = _context;
            var listProduct = ctx.Products.Where(p => p.CategoryId == id).ToList();
            foreach (var oProduct in listProduct)
            {
                if (oProduct != null)
                {
                    ctx.Products.Remove(oProduct);
                    ctx.SaveChanges();

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var fileName = Path.GetFileName(oProduct.ImagePath);
                    string path = Path.Combine(wwwRootPath + "/uploads/", fileName);
                    // Check if file exists with its full path    
                    if (System.IO.File.Exists(path))
                    {
                        // If file found, delete it    
                        System.IO.File.Delete(path);
                    }
                }
            }

            var oCategory = ctx.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
            ctx.Categories.Remove(oCategory);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
