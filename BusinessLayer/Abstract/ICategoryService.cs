using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);

        void Add(Category category);       
        void Delete(Category category);
        void Update(Category category);
    }
}