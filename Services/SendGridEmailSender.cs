using bmonsterman.security.service.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace bmonsterman.security.service.Services
{
    /// <inheritdoc/>
    /// <remarks>An implementation of <see cref="IEmailSender"/> for SendGrid.</remarks>
    public class SendGridEmailSender : IEmailSender
    {
        private string ApiKey { get; }

        /// <summary>
        ///   Initializes the SendGridEmailSender with the api key needed to
        ///   authenticate sending an email using the sendgrid email service.
        /// </summary>
        /// <param name="settings">The SendGridSettings contains the SendGridApiKey for sending an email
        /// using the sendgrid service.</param>
        public SendGridEmailSender(IOptions<SendGridSettings> settings)
        {
            ApiKey = settings.Value.SendGridApiKey;
        }

        /// <inheritdoc />
        public async Task SendEmailAsync(string emailAddress, string subject, string message)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("do-not-reply@bmonsterman.net");
            var to = new EmailAddress(emailAddress);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, message);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                throw new Exception($"SendGridClient could not send email, status:{response.StatusCode} body:{response.Body.ReadAsStringAsync().Result}");
        }
    }
}
