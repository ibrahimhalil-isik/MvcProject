using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        // GET: Talent
        public ActionResult Index()
        {
            var result = talentManager.GetAll();
            return View(result);
        }
        public ActionResult TalentCard()
        {
            var result = talentManager.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            talentManager.Add(talent);
            return RedirectToAction("TalentCard");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var result = talentManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            talentManager.Update(talent);
            return RedirectToAction("TalentCard");
        }

        public ActionResult DeleteTalent(int Id)
        {
            var result = talentManager.GetById(Id);
            talentManager.Delete(result);
            return RedirectToAction("TalentCard");
        }
    }
}