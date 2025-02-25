using LibraryManagementSystem.API.Models.DTO;
using LibraryManagementSystem.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenRepository = tokenRepository;
        }

        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            await EnsureRolesExist();
            var identityUser = new IdentityUser
            { 
                Email = registerRequestDto.Email,
                UserName = registerRequestDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                await userManager.AddClaimsAsync(identityUser, new[]
            {
                new Claim("Firstname", registerRequestDto.Firstname),
                new Claim("Lastname", registerRequestDto.Lastname)
            });
                identityResult = await userManager.AddToRolesAsync(identityUser, new[] { "Reader", "Writer" });

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please Log In");
                }
            }

            return BadRequest("Something Went Wrong");
        }

        private async Task EnsureRolesExist()
        {
            if (!await roleManager.RoleExistsAsync("Reader"))
            {
                await roleManager.CreateAsync(new IdentityRole("Reader"));
            }

            if (!await roleManager.RoleExistsAsync("Writer"))
            {
                await roleManager.CreateAsync(new IdentityRole("Writer"));
            }
        }

        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) 
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);

            if(user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    var claims = await userManager.GetClaimsAsync(user);

                    var firstNameClaim = claims.FirstOrDefault(c => c.Type == "Firstname")?.Value;
                    var lastNameClaim = claims.FirstOrDefault(c => c.Type == "Lastname")?.Value;

                    if (roles != null)
                    {
                        //Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                            Firstname = firstNameClaim,
                            Lastname = lastNameClaim
                        };

                        return Ok(response);
                    }
                   

                    return Ok();
                }
            }

            return BadRequest("Username or Password is incorrect");
        }
    }


}
