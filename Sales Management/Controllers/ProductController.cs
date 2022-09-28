using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Sales_Management.Data.Models;
using Sales_Management.Data;
using Sales_Management.Filter;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Sales_Management.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using ReflectionIT.Mvc.Paging;

namespace Sales_Management.Controllers
{
    [AdminActionFilter]
    [ProductActionFilter]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostEnvironment;

        public ProductController(AppDbContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "ProductName")
        {
            //return View(await _context.ProductCreateViewModel.ToListAsync());
            var qry = _context.tblProducts.AsNoTracking()
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.ProductName.Contains(filter));
            }
            var model = await PagingList.CreateAsync(qry, 2, page, sortExpression, "ProductName");
            model.RouteValue = new RouteValueDictionary
            {
                {"filter",filter }
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(VmProductCreate viewObj)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var result = false;
            string fileName = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extension = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtension = fileName + extension;
            tblProduct trObj = new tblProduct();
            trObj.ProductName = viewObj.ProductName;
            trObj.Price = viewObj.Price;
            trObj.OrderDate = viewObj.OrderDate;
            trObj.ImageName = fileWithExtension;
            trObj.ImageUrl = wwwRootPath + "/Images/" + fileName + extension;
            string serverPath = Path.Combine(wwwRootPath + "/Images/" + fileName + extension);
            using (var fileStream = new FileStream(serverPath, FileMode.Create))
            {
                await viewObj.ImageFile.CopyToAsync(fileStream);
            }
            //viewObj.ImageFile.CopyToAsync(serverPath);
            if (ModelState.IsValid)
            {
                if (viewObj.ProductId == 0)
                {
                    _context.tblProducts.Add(trObj);
                    _context.SaveChanges();
                    result = true;
                }
                else
                {
                    trObj.ProductId = viewObj.ProductId;
                    _context.Entry(trObj).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.ProductId == 0)
                {
                    return View("Create");
                }
                else
                {
                    return View("Edit");
                }
            }
        }

        public IActionResult Edit(int id)
        {
            tblProduct trObj = _context.tblProducts.SingleOrDefault(t => t.ProductId == id);
            VmProductCreate viewObj = new VmProductCreate();
            viewObj.ProductId = trObj.ProductId;
            viewObj.ProductName = trObj.ProductName;
            viewObj.Price = trObj.Price;
            viewObj.OrderDate = trObj.OrderDate;
            viewObj.ImageUrl = trObj.ImageUrl;
            viewObj.ImageName = trObj.ImageName;
            return View(viewObj);
        }

        public IActionResult Delete(int? id)
        {
            tblProduct trObj = _context.tblProducts.SingleOrDefault(t => t.ProductId == id);
            {
                _context.tblProducts.Remove(trObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //private bool ProductCreateViewModelExists(int id)
        //{
        //    return _context.ProductCreateViewModel.Any(e => e.ProductId == id);
        //}
    }
}
