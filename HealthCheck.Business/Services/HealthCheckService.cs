using HealthCheck.Business.Models;
using HealthCheck.Entity.Context;
using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;

namespace HealthCheck.Business.Services
{
    public class HealthCheckService
    {
        public static void Check()
        {
            using var scope = ServiceProviderFactory.ServiceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var applications = dbContext.Application.ToList();

            foreach (var application in applications)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://google.com/");

                var result = httpClient.GetAsync("api/health").Result;

                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MailRequest request = new MailRequest
                    {
                        Body = application.MailBody,
                        Name = application.Name,
                        ReceiverMail = application.Mail,
                        SenderMail = "ulkerozeren@gmail.com",
                        Subject = application.MailSubject
                    };
                  //  SendMail(request);
                }
            }
        }

        private static void SendMail(MailRequest request)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress(request.Name, request.SenderMail);
            message.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", request.ReceiverMail);
            message.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = request.Body;
            message.Body = bodyBuilder.ToMessageBody();

            message.Subject = request.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate(request.SenderMail, "dloz vvdy nzeu oqtk");
            smtpClient.Send(message);
            smtpClient.Disconnect(true);
        }
    }
}
