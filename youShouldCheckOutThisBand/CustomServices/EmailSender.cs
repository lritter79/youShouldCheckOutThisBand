using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace youShouldCheckOutThisBand.CustomServices
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(AuthMessageSenderOptions optionsAccessor)
        {
            Options = optionsAccessor;
        }

        private AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.ClientSecret, subject, message, email);
        }

        public async Task<Response> Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("levong2112@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            //// Disable click tracking.
            //// See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            ////msg.SetClickTracking(false, false);



            ////var client = new SendGridClient(apiKey);
            ////var from = new EmailAddress("test@example.com", "Example User");

            ////var to = new EmailAddress("test@example.com", "Example User");
            ////var plainTextContent = "and easy to do anywhere, even with C#";
            ////var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            ////var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var res = response.StatusCode;
            var bod = response.Body.ReadAsStringAsync().Result.ToString();
            var head = response.Headers.ToString();


            return response;
        }
    }
}
