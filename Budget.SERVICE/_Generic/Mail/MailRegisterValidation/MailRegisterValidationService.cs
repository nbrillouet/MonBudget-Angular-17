using Budget.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget.SERVICE
{
    public class MailRegisterValidationService : IMailRegisterValidationService
    {
        private readonly IMailService _mailService;

        public MailRegisterValidationService(
            IMailService mailService
            )
        {
            _mailService = mailService;
        }

        public void SendRegisterValidationMail(User user)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "datas/MailingTemplate", "mailRegisterValidation.htm");

            string htmlPart = File.ReadAllText(file);
            htmlPart = htmlPart.Replace("[ACTIVATION_CODE]", user.ActivationCode);

            _mailService.SendEmailAsync(user.Email, user.UserName, "Validation inscription", htmlPart);
        }
    }
}
    //    private string HtmlPart { get; set; }

        //    public MailRegisterValidationService()
        //    {

        //        var pathToFile = env.ApplicationBasePath
        //    }

        //    public async Task SendEmailAsync()
        //    {
        //        var toto = Environment.GetEnvironmentVariable("1797f736f9dd7b316dc37d213e8f2fa5");
        //        var titi = Environment.GetEnvironmentVariable("9aea6ff1bc352cbe84f11399cde5ef60");

        //        MailjetClient client = new MailjetClient(
        //            "1797f736f9dd7b316dc37d213e8f2fa5",
        //            "9aea6ff1bc352cbe84f11399cde5ef60"
        //            //Environment.GetEnvironmentVariable("1797f736f9dd7b316dc37d213e8f2fa5"),
        //            //Environment.GetEnvironmentVariable("9aea6ff1bc352cbe84f11399cde5ef60")
        //            )
        //        {
        //            Version = ApiVersion.V3_1,
        //        };
        //        MailjetRequest request = new MailjetRequest
        //        {
        //            Resource = Send.Resource,
        //        }
        //         .Property(Send.Messages, new JArray {
        // new JObject {
        //  {
        //   "From",
        //   new JObject {
        //    {"Email", "nico_brillouet@hotmail.com"},
        //    {"Name", "nicolas"}
        //   }
        //  }, {
        //   "To",
        //   new JArray {
        //    new JObject {
        //     {
        //      "Email",
        //      "nico_brillouet@hotmail.com"
        //     }, {
        //      "Name",
        //      "nicolas"
        //     }
        //    }
        //   }
        //  }, {
        //   "Subject",
        //   "Greetings from Mailjet."
        //  }, {
        //   "TextPart",
        //   "My first Mailjet email"
        //  }, {
        //   "HTMLPart",
        //   "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
        //  }, {
        //   "CustomID",
        //   "AppGettingStartedTest"
        //  }
        // }
        //         });
        //        MailjetResponse response = await client.PostAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
        //            Console.WriteLine(response.GetData());
        //        }
        //        else
        //        {
        //            Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
        //            Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
        //            Console.WriteLine(response.GetData());
        //            Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
        //        }
        //    }
        //}
    //}

