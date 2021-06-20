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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }
        public void Add(Talent talent)
        {
            _talentDal.Add(talent);
        }

        public void Delete(Talent talent)
        {
            _talentDal.Delete(talent);
        }
           
        public List<Talent> GetAll()
        {
            return _talentDal.GetAll();
        }

        public Talent GetById(int talentId)
        {
            return _talentDal.Get(t => t.TalentId == talentId);
        }

        public void Update(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
