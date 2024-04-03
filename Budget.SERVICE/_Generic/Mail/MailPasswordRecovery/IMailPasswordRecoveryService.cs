using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IMailPasswordRecoveryService
    {
        void SendPasswordRecoveryMail(User user);
    }
}
