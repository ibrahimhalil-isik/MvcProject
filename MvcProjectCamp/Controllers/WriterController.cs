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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidation writerValidation = new WriterValidation();

        public ActionResult Index()
        {
            var result = writerManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer writer)
        {            
            ValidationResult validationResult = writerValidation.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.Add(writer);
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

        public ActionResult Delete(int writerId)
        {
            var result = writerManager.GetById(writerId);
            writerManager.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int writerId)
        {
            var result = writerManager.GetById(writerId);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            ValidationResult validationResult = writerValidation.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.Update(writer);
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