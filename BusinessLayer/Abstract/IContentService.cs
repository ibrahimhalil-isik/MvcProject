using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByHeadingId(int headingId);
        Content GetById(int contentId);

        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
    }
}
