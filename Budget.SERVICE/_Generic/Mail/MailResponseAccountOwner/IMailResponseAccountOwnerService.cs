using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IMailResponseAccountOwnerService
    {
        void SendResponseAccountOwnerMail(AccountOwnerDto  accountOwnerDto);
    }

}
