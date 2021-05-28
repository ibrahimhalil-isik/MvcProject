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
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidation = new HeadingValidator();

        // GET: Heading

        public ActionResult Index()
        {
            var result = headingManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {

            List<SelectListItem> categoryValue = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> writerValue = (from x in writerManager.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterId.ToString()
                                                }
                                                ).ToList();

            ViewBag.categoryValue = categoryValue;
            ViewBag.writerValue = writerValue;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ValidationResult validationResult = headingValidation.Validate(heading);
            if (validationResult.IsValid)
            {
                headingManager.Add(heading);
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

        public ActionResult Delete(int headingId)
        {
            var result = headingManager.GetById(headingId);

            if (result.HeadingStatus == true)
            {
                result.HeadingStatus = false;
            }
            else
            {
                result.HeadingStatus = true;
            }
            
            headingManager.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int headingId)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.categoryValue = categoryValue;

            var result = headingManager.GetById(headingId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            
            ValidationResult validationResult = headingValidation.Validate(heading);
            if (validationResult.IsValid)
            {
                headingManager.Update(heading);
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
    }
}