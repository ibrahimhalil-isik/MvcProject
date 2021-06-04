using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ImageFileController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        // GET: ImageFile

        [HttpGet]
        public ActionResult Index()
        {
            var result = imageFileManager.GetAll();
            return View(result);
        }
    }
}