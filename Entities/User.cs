using Microsoft.AspNetCore.Identity;
using System;

namespace bmonsterman.security.service.Entities
{
     /// <inheritdoc />
    /// <remarks>
    ///   A user.  Extends Identity user and sets the data type of the key to an integer.
    /// </remarks>
    public class User : IdentityUser<int>
    {
        /// <summary>
        ///   The user's first name.
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        ///   The user's last name.
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        ///   The filename for the image for the user's Profile
        /// </summary>
        public virtual string ProfileImageFilename { get; set; }

        /// <summary>
        ///   The last time the  user logged in.
        /// </summary>
        public virtual DateTimeOffset? LastSignedIn { get; set; }
    }  
}