using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_Management.Data.Models;
using Sales_Management.Data;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace Sales_Management.Controllers
{
    public class AjaxController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostEnvironment;

        public AjaxController(AppDbContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }
        IEnumerable<ProductA> GetAllEmployee()
        {
            using (AppDbContext db = _context)
            {
                return db.ProductAs.ToList<ProductA>();
            }
        }
        public IActionResult AddOrEdit(int id = 0)
        {
            ProductA emp = new ProductA();
            if (id != 0)
            {
                using (AppDbContext db = _context)
                {
                    emp = db.ProductAs.Where(x => x.ProductID == id).FirstOrDefault<ProductA>();
                }
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult AddOrEdit(ProductA emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = wwwRootPath + "/ImagesA/" + fileName;
                    using (var fileStream = new FileStream(emp.ImagePath, FileMode.Create))
                    {
                        emp.ImageUpload.CopyTo(fileStream);
                    }
                    //emp.ImageUpload.CopyTo(Path.Combine(wwwRootPath+"/ImagesA/", fileName));
                }
                using (AppDbContext db = _context)
                {
                    if (emp.ProductID == 0)
                    {
                        db.ProductAs.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                //return RedirectToAction("ViewAll");
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
