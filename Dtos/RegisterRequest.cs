using System.ComponentModel.DataAnnotations;

namespace bmonsterman.security.service.Dtos
{
    /// <summary>
    ///   Defines the data elements for making a register request.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        ///   The email address of the registrant.
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        /// <summary>
        ///   The password of the registrant.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        ///   The first name of the registrant.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        ///   The last name of the registrant.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        ///   The url for the email confirmation page that will be embedded in the email message.
        /// </summary>
        [Required]
        public string ConfirmAccountUrl { get; set; }
    }
}