using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var result = aboutManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(About about)
        {
            AboutValidator aboutValidator = new AboutValidator();
            ValidationResult validationResult = aboutValidator.Validate(about);
            if (validationResult.IsValid)
            {
                aboutManager.Add(about);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        public PartialViewResult AddAbuotPartial()
        {
            return PartialView();
        }
    }
}