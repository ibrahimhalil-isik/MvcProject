using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidation = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var result = contactManager.GetAll();
            return View(result);
        }

        public ActionResult GetContactDetails(int contactId)
        {
            var result = contactManager.GetById(contactId);
            return View(result);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}