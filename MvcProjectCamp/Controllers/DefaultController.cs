using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var result = headingManager.GetAll();
            return View(result);
        }
        // GET: Default
        public PartialViewResult Index(int id = 0)
        {
            var result = contentManager.GetAllByHeadingId(id);
            return PartialView(result);
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}