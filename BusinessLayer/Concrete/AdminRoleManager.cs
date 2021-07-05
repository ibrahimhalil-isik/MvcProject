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
    public class AdminRoleManager : IAdminRoleService
    {

        IAdminRoleDal _adminRoleDal;

        public AdminRoleManager(IAdminRoleDal adminRoleDal)
        {
            _adminRoleDal = adminRoleDal;
        }

        public List<AdminRole> GetAll()
        {
            return _adminRoleDal.GetAll();
        }
    }
}
