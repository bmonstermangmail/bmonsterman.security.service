using bmonsterman.security.service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace bmonsterman.security.service.Controllers
{
    /// <summary>
    ///   Manages a users own account. Allows them to 
    ///       1. register
    ///       2. sign in 
    ///       3. reset a forgotten password
    ///       4. change their password
    ///       5. change their profile
    ///   Allows an admin to unlock a user
    /// </summary>
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok("Image 7");
        }


        /// <summary>
        ///   Registers a new user.
        /// </summary>
        /// <param name="registerRequest">The request, <see cref="RegisterRequest"/>,  for registering a user.</param>
        /// <returns>A response that includes information about the new <see cref="User"/>.  Includes an auth cookie if registration succeeds.</returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (registerRequest == null)
                return BadRequest("Request body must contain register information");

            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}