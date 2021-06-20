using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        bool Login(AdminLoginDto adminLoginDto);
        bool WriterLogin(WriterLoginDto writerLoginDto);
        void WriterRegister(string mail, string password);

    }
}
