using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dto;
using MvcProjectCamp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        Context context = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginDto loginDto)
        {

            if (authService.Login(loginDto))
            {
                FormsAuthentication.SetAuthCookie(loginDto.AdminUserName, false);
                Session["AdminUserName"] = loginDto.AdminUserName;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }

        public ActionResult WriterLogOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(WriterLoginDto writerLoginDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.WriterLogin(writerLoginDto))
            {
                FormsAuthentication.SetAuthCookie(writerLoginDto.WriterEmail, false);
                Session["WriterEmail"] = writerLoginDto.WriterEmail;
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
    }
}