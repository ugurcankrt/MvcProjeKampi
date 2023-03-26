using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statictic

        Context c = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.v1= c.Categories.Count();
            ViewBag.v2 = c.Headings.Where(x => x.CategoryID == 1009).Count();
            ViewBag.v3 = c.Writers.Where(c => c.WriterName.Contains("a")).Count();
            ViewBag.v4 = c.Headings.Max(y => y.Category.CategoryName);
            ViewBag.v5 = c.Categories.Where(x => x.CategoryStatus).Count() - c.Categories.Where(x => !x.CategoryStatus).Count();
            return View();
        }
    }
}
