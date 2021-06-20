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
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int adminId)
        {
            return _adminDal.Get(a => a.AdminId == adminId);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
