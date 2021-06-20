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

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int messageId)
        {
            return _messageDal.Get(m => m.MessageId == messageId);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.GetAll(m => m.ReceiverMail == "ibrahim@halil.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.GetAll(m => m.SenderMail == "ibrahim@halil.com");
        }

        public List<Message> GetAllRead()
        {
            return _messageDal.GetAll(m => m.ReceiverMail == "admin@gail.com").Where(m => m.IsRead == false).ToList();
        }

        public List<Message> IsDraft()
        {
            return _messageDal.GetAll(m => m.IsDraft == true);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
