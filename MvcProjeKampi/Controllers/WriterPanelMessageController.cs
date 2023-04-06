using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult InBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInBox(p);
            ViewBag.unOpenedMessage = messageManager.GetCountUnOpenedReceiverMessage(p);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendBox(p);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return View(messageValues);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValues = messageManager.GetByID(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            string sender = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult IsOpened(int id)
        {
            var messageValue = messageManager.GetByID(id);

            if (!messageValue.IsOpened)
            {
                messageValue.IsOpened = true;
                messageManager.MessageUpdate(messageValue);
            }
            return RedirectToAction("Inbox");
        }

        public PartialViewResult MessageListMenuPartial()
        {
            string result = (string)Session["WriterMail"];
            ViewBag.InBoxMessageCount = messageManager.GetCountUnOpenedReceiverMessage(result);
            ViewBag.SendBoxMessageCount = messageManager.GetCountUnOpenedSenderMessage(result);
            return PartialView();
        }
    }
}