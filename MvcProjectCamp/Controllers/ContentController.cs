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
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());

        [HttpGet]
        public ActionResult Index()
        {
            var result = contentManager.GetAll();
            return View(result);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Content content)
        {
            ContentValidator contentValidator = new ContentValidator();
            ValidationResult validationResult = contentValidator.Validate(content);
            if (validationResult.IsValid)
            {
                contentManager.Add(content);
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

        public ActionResult Delete(int contentId)
        {
            var result = contentManager.GetById(contentId);
            contentManager.Delete(result); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int contentId)
        {
            var result = contentManager.GetById(contentId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Content content)
        {
            contentManager.Update(content);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ContentByHeading(int headingId)
        {
            var result = contentManager.GetAllByHeadingId(headingId);
            return View(result);
        }
    }
}