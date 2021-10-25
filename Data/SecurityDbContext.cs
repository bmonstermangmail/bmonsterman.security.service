using bmonsterman.security.service.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bmonsterman.security.service.Data
{
    /// <remarks>
    ///   Data Access Layer for the for Bmonsterman
    /// </remarks>
    public class SecurityDbContext : IdentityDbContext<User, Role, int>
    {
        /// <inheritdoc cref="IdentityDbContext{TUser,TRole,TKey}" />
        public SecurityDbContext(DbContextOptions options) : base(options)
        {
           
        }
    }
}
