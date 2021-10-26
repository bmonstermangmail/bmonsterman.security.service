using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace bmonsterman.security.service.Services.Extensions
{
    public static class EmailSenderExtensions
    {
        /// <summary>
        ///   Creates the confirm account body of the email and sends the message
        /// </summary>
        /// <param name="emailSender">The <see cref="IEmailSender"/> used to send the message.</param>
        /// <param name="email">The email address to send the confirm account email to.</param>
        /// <param name="confirmAccountPageUrl">The url for the confirm account page.</param>
        /// <returns></returns>
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string confirmAccountPageUrl)
        {
            if (emailSender == null)
                throw new ArgumentException(nameof(emailSender));

            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (email == string.Empty)
                throw new ArgumentException("cannot be empty", nameof(email));

            if (confirmAccountPageUrl == null)
                throw new ArgumentException("cannot be empty", nameof(confirmAccountPageUrl));

            if (confirmAccountPageUrl == string.Empty)
                throw new ArgumentException("cannot be empty", nameof(confirmAccountPageUrl));

            // TODO: localize the email message
            var message = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(confirmAccountPageUrl)}'>clicking here</a>";

            return emailSender.SendEmailAsync(email, "Confirm your email", message);
        }

        /// <summary>
        ///   Creates the reset password body of the email and sends the message
        /// </summary>
        /// <param name="emailSender">The <see cref="IEmailSender"/> used to send the message.</param>
        /// <param name="email">The email address to send the reset password email to.</param>
        /// <param name="resetPasswordPageUrl">The url for the reset password page.</param>
        /// <returns></returns>
        public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string resetPasswordPageUrl)
        {
            if (emailSender == null)
                throw new ArgumentNullException(nameof(emailSender));

            if (email == null)
                throw new ArgumentNullException(nameof(email));

            if (email == string.Empty)
                throw new ArgumentException("cannot be empty", nameof(email));

            if (resetPasswordPageUrl == null)
                throw new ArgumentNullException(nameof(resetPasswordPageUrl));

            if (resetPasswordPageUrl == string.Empty)
                throw new ArgumentException("cannot be empty", nameof(resetPasswordPageUrl));

            // TODO: localize the email message.
            var message = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(resetPasswordPageUrl)}'>clicking here</a>.";

            return emailSender.SendEmailAsync(email, "Reset Password", message);
        }
    }
}
