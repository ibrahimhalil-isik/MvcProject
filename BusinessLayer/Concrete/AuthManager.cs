using BusinessLayer.Abstract;
using BusinessLayer.Utilities.Security.Hashing;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        public bool Login(AdminLoginDto adminLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminLoginDto.AdminUserName));
                var user = _adminService.GetAll();
                foreach (var item in user)
                {
                    if (HashingHelper.VerifyPasswordHash(adminLoginDto.AdminUserName, adminLoginDto.AdminPassword, item.AdminUserName, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void Register(string userName, string password)
        {
            byte[] userNameHash, passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userName, password, out userNameHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = userNameHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminRoleId = 3
            };
            _adminService.Add(admin);
        }

        public bool WriterLogin(WriterLoginDto writerLoginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var writer = _writerService.GetAll();
                foreach (var item in writer)
                {
                    if (HashingHelper.WriterVerifyPasswordHash(writerLoginDto.WriterPassword, item.WriterPasswordHash, item.WriterPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void WriterRegister(string mail, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.WriterCreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterEmail = mail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
            };
            _writerService.Add(writer);
        }


    }
}
