using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetAll();
        void Add(Talent talent);
        void Update(Talent talent);
        void Delete(Talent talent);
        Talent GetById(int talentId);
    }
}
