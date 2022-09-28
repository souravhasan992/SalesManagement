using Microsoft.AspNetCore.Mvc;
using Sales_Management.Data.Models;
using Sales_Management.Data;
using System.Collections.Generic;
using System.Linq;
using Sales_Management.Data.ViewModels;

namespace Sales_Management.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Permisions()
        {
            return View(_context.UserLogins.ToList());
        }

        public IActionResult Permision()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Permision(UserLogin model, int[] menuId, bool[] isRead, bool[] isCreate, bool[] isUpdate, bool[] isDelete)
        {
            var list = new List<UserPermission>();
            for (int i = 0; i < menuId.Length; i++)
            {
                var obj = new UserPermission();
                obj.MenuIid = menuId[i];
                obj.IsRead = isRead[i];
                obj.IsCreate = isCreate[i];
                obj.IsUpdate = isUpdate[i];
                obj.IsDelete = isDelete[i];
                obj.UserId = model.UserId;

                list.Add(obj);
            }
            _context.UserLogins.AddAsync(model);
            _context.UserPermissions.AddRangeAsync(list);
            _context.SaveChangesAsync();
            return RedirectToAction("Permisions");
        }

        public IActionResult PermisionEdit(int id)
        {
            VmUserPermission oVmUserPermission = new VmUserPermission();
            oVmUserPermission.UserLogin = _context.UserLogins.Where(o => o.UserId == id).FirstOrDefault();
            oVmUserPermission.ListUserPermission = _context.UserPermissions.Where(o => o.UserId == id).ToList();
            return View(oVmUserPermission);
        }

        [HttpPost]
        public IActionResult PermisionEdit(UserLogin model, int[] permissionId, int[] menuId, bool[] isRead, bool[] isCreate, bool[] isUpdate, bool[] isDelete)
        {
            var list = new List<UserPermission>();
            for (int i = 0; i < menuId.Length; i++)
            {
                var obj = _context.UserPermissions.Where(o => o.UserId == permissionId[i]).FirstOrDefault();
                if (obj != null)
                {
                    obj.MenuIid = menuId[i];
                    obj.IsRead = isRead[i];
                    obj.IsCreate = isCreate[i];
                    obj.IsUpdate = isUpdate[i];
                    obj.IsDelete = isDelete[i];
                    obj.UserId = model.UserId;
                }
                list.Add(obj);
            }
            _context.UserLogins.Update(model);
            _context.UserPermissions.UpdateRange(list);
            _context.SaveChangesAsync();
            return RedirectToAction("Permisions");
        }

    }
}
