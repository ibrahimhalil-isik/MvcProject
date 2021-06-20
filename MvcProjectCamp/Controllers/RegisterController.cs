using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLoginDto adminLoginDto)
        {
            authService.Register(adminLoginDto.AdminUserName, adminLoginDto.AdminPassword);
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLoginDto)
        {
            authService.WriterRegister(writerLoginDto.WriterEmail, writerLoginDto.WriterPassword);
            return RedirectToAction("WriterLogin", "Login");
        }
    }
}