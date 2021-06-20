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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllByHeadingId(int headingId)
        {
            return _contentDal.GetAll(c => c.HeadingId == headingId);
        }

        public List<Content> GetListByWriter(int writerId)
        {
            return _contentDal.GetAll(c => c.WriterId == writerId);
        }
        public Content GetById(int contentId)
        {
            return _contentDal.Get(c => c.ContentId == contentId);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
