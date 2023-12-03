using BEN.DTOs;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyWebApiStudentGPA.Controllers
{
    public class TokenVerifier
    {
        public string Token { get; set; }

        public string jwt { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ITokenServices _tokenServices;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<AppRole> roleManager,
                                 ITokenServices tokenServices
                                )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _roleManager = roleManager;
        }




        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
             
             var user = await _userManager.FindByEmailAsync(loginDto.Email);
            

            if (user == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Email or Password");
            }

            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = await _tokenServices.CreateToken(user),
                DisplayName = user.DisplayName,
                ProfilePicturUrl = user.ProfilPicture,
                RefreshToken = ""
            };
        }


        [HttpPost("register")]
        public async Task<ActionResult<EmailConfirmationDto>> Register(RegisterDto registerDto)
        {

            try
            {
                var user = await _userManager.FindByEmailAsync(registerDto.Email);
                if (user != null)
                {
                   return BadRequest("Email already exist");
                }

                var Appuser = new AppUser()
                {
                    Email = registerDto.Email,
                    DisplayName = registerDto.DisplayName,
                    Gender = "",
                    TwoFactorEnabled = false,
                    ProfilPicture = "",
                    UserName = registerDto.Email 
                }; 

                var result = await _userManager.CreateAsync(Appuser, registerDto.Password);

                if (!result.Succeeded)
                {
                   
                    return BadRequest(result.Errors.FirstOrDefault()?.Description ?? "");
                }

                //var Roles = new RoleController(_roleManager, _userManager);
                //await Roles.AssignRoleToUser(new RoleAssignmentDto()
                //{
                //    RoleName = registerDto.Role,
                //    UserId = user.Id
                //});
                //var token = await SendEmailToUserAsync(user, registerDto.Link);
                
                return new EmailConfirmationDto
                {
                    Email = Appuser.Email,
                    UserName = Appuser.UserName,
                    DisplayName = Appuser.DisplayName,
                };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }



       
    }
}
