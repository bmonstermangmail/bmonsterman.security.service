using System.Threading.Tasks;
using bmonsterman.security.service.Entities;
using Microsoft.AspNetCore.Identity;

namespace bmonsterman.security.service.Services
{
    public interface IUserManager
    {
        /// <summary>
        ///   Creates a user account
        /// </summary>
        /// <param name="user">The user being created.</param>
        /// <param name="password">The password the user will enter to verify identity.</param>
        /// <returns>An <see cref="IdentityResult"/> indicating success or failure.</returns>
        Task<IdentityResult> CreateAsync(User user, string password);

        /// <summary>
        ///   Generates a token (or code) that will be used to verify a user's registration
        ///   by email
        /// </summary>
        /// <param name="user">The user account or <see cref="User"/> being verified.</param>
        /// <returns>The token as a string.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
    }
}