using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace JobCraft.Repositories.Implementation
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmailAsync(string email, string subject, string confirmLink)
        {
            try
            {
                sib_api_v3_sdk.Client.Configuration.Default.ApiKey["api-key"] = _configuration["ApiKeys:BrevoApi"];
                var apiInstance = new TransactionalEmailsApi();
                string SenderName = "JobCraft";
                string SenderEmail = "wulaia.anri@gmail.com";
                SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
                string ToName = "NewUser";
                SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(email, ToName);
                List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
                To.Add(smtpEmailTo);

                var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, confirmLink, null, subject);
                CreateSmtpEmail result = await apiInstance.SendTransacEmailAsync(sendSmtpEmail);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
