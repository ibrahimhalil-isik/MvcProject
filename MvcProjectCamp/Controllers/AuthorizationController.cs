using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {

        AdminRoleManager adminRoleManager = new AdminRoleManager(new EfAdminRoleDal());

        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var result = adminManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int adminId)
        {
            List<SelectListItem> adminRoleValue = (from x in adminRoleManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Role,
                                                   Value = x.AdminRoleId.ToString()
                                               }).ToList();

            ViewBag.adminRoleValue = adminRoleValue;
            var result = adminManager.GetById(adminId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }

        public ActionResult Status(int adminId)
        {
            var result = adminManager.GetById(adminId);
            if (result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            adminManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}