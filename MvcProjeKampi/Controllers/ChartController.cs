using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category()
            {
                CategoryName = "Yazılım",
                CategoryValue = 8
            });

            categories.Add(new Category()
            {
                CategoryName = "Eğitim",
                CategoryValue = 4
            });

            categories.Add(new Category()
            {
                CategoryName = "Spor",
                CategoryValue = 4
            });

            categories.Add(new Category()
            {
                CategoryName = "Sanat",
                CategoryValue = 10
            });

            return categories;
        }

        public ActionResult WriterHeadingIndex()
        {
            return View();
        }
        public ActionResult WriterHeadingChart()
        {
            return Json(WriterHeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<WriterHeadingCount> WriterHeadingList()
        {
            //Yazarların açtığı başlık sayısı
            List<WriterHeadingCount> writerHeadingCounts = new List<WriterHeadingCount>();
            using (var Context = new Context())
            {
                writerHeadingCounts = Context.Writers.Select(x => new WriterHeadingCount
                {
                    WriterName = x.WriterName,
                    HeadingCount = x.Headings.Count()
                }).ToList();
            };
            return writerHeadingCounts;
        }

        public ActionResult HeadingChartIndex()
        {
            return View();
        }
        public ActionResult HeadingChart()
        {
            return Json(HeadingEntryList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingByContentCount> HeadingEntryList()
        {
            List<HeadingByContentCount> headingClasses = new List<HeadingByContentCount>();
            using (var Context = new Context())
            {
                headingClasses = Context.Headings.Select(x => new HeadingByContentCount
                {
                    HeadingName = x.HeadingName,
                    ContentValue = x.Contents.Count()
                }).ToList();
            };
            return headingClasses;
        }

    }
}