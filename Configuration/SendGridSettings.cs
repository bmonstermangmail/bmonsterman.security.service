namespace bmonsterman.security.service.Configuration
{
    /// <summary>
    ///    Configuration for the SendGrid account for the security service
    /// </summary>
    public class SendGridSettings
    {
        /// <summary>
        ///  The api key from sendgrid for the security service.
        /// </summary>
        public string SendGridApiKey { get; set; }
    }
}
