using Budget.MODEL;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Budget.SERVICE
{

    public class MailAskAccountOwnerService : IMailAskAccountOwnerService
    {
        private readonly IMailService _mailService;

        public MailAskAccountOwnerService(
            IMailService mailService
            )
        {
            _mailService = mailService;
        }

        public void SendAskAccountOwnerMail(User userCaller, User userOwner, string accountNumber)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "datas", "MailingTemplate", "mailAskAccountOwner.htm");
            string htmlPart = File.ReadAllText(file);

            htmlPart = htmlPart.Replace("[USER_CALLER_INFO]", $"{userCaller.FirstName} {userCaller.LastName}");
            htmlPart = htmlPart.Replace("[ACCOUNT_NUMBER]", $"{accountNumber}");

            string linkpath = $"http://localhost:4200/pages/interact/account-owner/";
            var responseEncryptYes = HELPER.CryptoHelper.Encrypt($"{accountNumber}_{userOwner.Id}_{userCaller.Id}_{EnumActivationCode.Active.ToString()}");
            var responseEncryptNo = HELPER.CryptoHelper.Encrypt($"{accountNumber}_{userOwner.Id}_{userCaller.Id}_{EnumActivationCode.Refused.ToString()}");

            var responseEncryptYesLink = $"{linkpath}{HttpUtility.UrlEncode(responseEncryptYes)}";
            var responseEncryptNoLink = $"{linkpath}{HttpUtility.UrlEncode(responseEncryptNo)}";

            htmlPart = htmlPart.Replace("[ASK_ACCOUNT_YES_LINK]", $"{responseEncryptYesLink}");
            htmlPart = htmlPart.Replace("[ASK_ACCOUNT_NO_LINK]", $"{responseEncryptNoLink}");

            _mailService.SendEmailAsync(userOwner.Email, userOwner.UserName, "Demande de partage de compte", htmlPart);
        }
    }
    
}
