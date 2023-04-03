using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult ContactDetailsPartial()
        {
            ViewBag.ContactMessageCount = contactManager.GetList().Count();
            ViewBag.InBoxMessageCount = messageManager.GetCountUnOpenedReceiverMessage("uk@gmail.com");
            ViewBag.SendBoxMessageCount = messageManager.GetCountUnOpenedSenderMessage("uk@gmail.com");

            return PartialView();
        }
    }
}