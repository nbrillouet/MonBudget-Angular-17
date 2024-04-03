using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget.SERVICE
{
    public class MailPasswordRecoveryService: IMailPasswordRecoveryService
    {
        private readonly IMailService _mailService;

        public MailPasswordRecoveryService(
            IMailService mailService
            )
        {
            _mailService = mailService;
        }

        public void SendPasswordRecoveryMail(User user)
        {
            string encryptId = HELPER.CryptoHelper.Encrypt(user.Id.ToString());
            string linkpath = $"http://localhost:4200/pages/auth/reset-password/{encryptId}";

            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "datas/MailingTemplate", "mailPasswordRecovery.htm");
            string htmlPart = File.ReadAllText(file);

            htmlPart = htmlPart.Replace("[RECOVERY_PASSWORD_LINK]", linkpath);

            _mailService.SendEmailAsync(user.Email, user.UserName, "Réinitialisation mot de passe", htmlPart);
        }
    }
}
