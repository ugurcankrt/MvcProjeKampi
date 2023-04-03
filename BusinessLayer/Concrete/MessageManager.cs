using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInBox()
        {
            return _messageDal.List(x => x.ReceiverMail == "uk@gmail.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messageDal.List(x => x.SenderMail == "uk@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public int MessageCount()
        {
            return _messageDal.List().Count();
        }

        public int GetCountUnOpenedReceiverMessage(string p)
        {
            return _messageDal.List(x => /*!x.IsOpened && */ x.ReceiverMail == p).Count();
        }

        public int GetCountUnOpenedSenderMessage(string p)
        {
            return _messageDal.List(x => /*!x.IsOpened && */ x.SenderMail == p).Count();
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
