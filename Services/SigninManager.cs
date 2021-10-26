
using bmonsterman.security.service.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace bmonsterman.security.service.Services
{
    public class SigninManager : SignInManager<User>, ISignInManager
    {
        public SigninManager(UserManager<User> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<User> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<User>> logger, 
            IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, null) { 
        }
    }

}