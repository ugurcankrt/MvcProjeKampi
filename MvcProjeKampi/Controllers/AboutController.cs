using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.AboutAdd(p);
            p.AbouStatus = true;
            return RedirectToAction("Index");
        }

        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }

        public ActionResult StatusChangeAbout(int id)
        {
            var aboutValue = aboutManager.GetByID(id);
            if (aboutValue.AbouStatus)
            {
                aboutValue.AbouStatus = false;
            }
            else
            {
                aboutValue.AbouStatus = true;
            }
            aboutManager.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
    }
}