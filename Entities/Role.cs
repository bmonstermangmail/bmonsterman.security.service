using Microsoft.AspNetCore.Identity;

namespace bmonsterman.security.service.Entities
{
    /// <inheritdoc />
    /// <summary>
    ///   Defines the a role that may be assigned to a user for authorization. Extends
    ///   Identity role and sets the data type for the key to an integer.
    /// </summary>
    public class Role : IdentityRole<int>
    {
        /// <summary>
        ///   Indicates if the role can be deleted.
        /// </summary>
        public virtual bool CanDelete { get; set; }

        /// <summary>
        ///  Indicates if the role can be edited.
        /// </summary>
        public virtual bool CanEdit { get; set; }
    }
}
