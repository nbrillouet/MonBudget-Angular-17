using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Budget.SERVICE
{
    public interface IMailAskAccountOwnerService
    {
        void SendAskAccountOwnerMail(User userCaller, User userOwner, string accountNumber);
    }
}
