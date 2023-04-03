using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult InBox()
        {
            var messageList = messageManager.GetListInBox();
            ViewBag.unOpenedMessage = messageManager.GetCountUnOpenedReceiverMessage("uk@gmail.com");
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = messageManager.GetListSendBox();
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
            if (results.IsValid)
            {
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
    }
}