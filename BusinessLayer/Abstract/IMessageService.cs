using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetAllRead();
        List<Message> IsDraft();
        Message GetById(int messageId);

        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
    }
}
