using Budget.MODEL.Dto;
using Budget.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{

    public class MailResponseAccountOwnerService: IMailResponseAccountOwnerService
    {
        private readonly IMailService _mailService;

        public MailResponseAccountOwnerService(
            IMailService mailService
            )
        {
            _mailService = mailService;
        }

        public void SendResponseAccountOwnerMail(AccountOwnerDto accountOwnerDto)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "datas", "MailingTemplate", "mailResponseAccountOwner.htm");
            string htmlPart = File.ReadAllText(file);

            htmlPart = htmlPart.Replace("[USER_OWNER_INFO]", $"{accountOwnerDto.UserOwner.FirstName} {accountOwnerDto.UserOwner.LastName}");
            htmlPart = htmlPart.Replace("[ACCOUNT_NUMBER]", $"{accountOwnerDto.Account.Number}");
            htmlPart = htmlPart.Replace("[RESPONSE]", accountOwnerDto.EnumActivationCode == EnumActivationCode.Active ? "autorisé" : "refusé");

            //string linkpath = $"http://localhost:4200/pages/interact/account-owner/";
            //var responseEncryptYes = HELPER.CryptoHelper.Encrypt($"{accountNumber}_{userOwner.Id}_{userCaller.Id}_{EnumActivationCode.Active.ToString()}");
            //var responseEncryptNo = HELPER.CryptoHelper.Encrypt($"{accountNumber}_{userOwner.Id}_{userCaller.Id}_{EnumActivationCode.Refused.ToString()}");

            //var responseEncryptYesLink = $"{linkpath}{HttpUtility.UrlEncode(responseEncryptYes)}";
            //var responseEncryptNoLink = $"{linkpath}{HttpUtility.UrlEncode(responseEncryptNo)}";

            //htmlPart = htmlPart.Replace("[ASK_ACCOUNT_YES_LINK]", $"{responseEncryptYesLink}");
            //htmlPart = htmlPart.Replace("[ASK_ACCOUNT_NO_LINK]", $"{responseEncryptNoLink}");

            _mailService.SendEmailAsync(accountOwnerDto.UserCaller.MailAddress,$"{accountOwnerDto.UserCaller.FirstName} {accountOwnerDto.UserCaller.LastName}", "Demande de partage de compte", htmlPart);
        }
    }
}

