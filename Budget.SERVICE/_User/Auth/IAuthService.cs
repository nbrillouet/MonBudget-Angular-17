using Budget.MODEL;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IAuthService
    {
        User Register(UserForRegister userForRegister);
        User ActivateAccount(string activationCode);
        UserForRegister GetUserEncrypt(string userId);
        bool ChangePassword(UserForPasswordChange userForPasswordChange);
        void PasswordRecovery(string mail);
        UserForAuth Login(string username, string password);
    }
}
