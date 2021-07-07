using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ScheduleController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Schedule
        public ActionResult Index()
        {
            var result = headingManager.GetAll();
            return View(result);
        }
    }
}