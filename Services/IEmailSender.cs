using System.Threading.Tasks;

namespace bmonsterman.security.service.Services
{
    /// <summary>
    ///   Sends emails.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        ///   Sends an email
        /// </summary>
        /// <param name="emailAddress">The emailAddress address for the emailAddress</param>
        /// <param name="subject">The subject for the emailAddress</param>
        /// <param name="message">The message for the emailAddress</param>
        /// <returns><see cref="Task"/> with no result.</returns>
        Task SendEmailAsync(string emailAddress, string subject, string message);
    }
}
