using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/Gallery/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                imageFileManager.Add(ımageFile);
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}