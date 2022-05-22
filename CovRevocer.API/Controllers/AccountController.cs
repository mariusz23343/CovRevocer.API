using CovRecover.API.Dtos;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CovRecover.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if(user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if(result.Succeeded)
            {
                return CreateUserDto(user);
            }

            return Unauthorized(); 
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register (RegisterDto dto)
        {
            if(await _userManager.Users.AnyAsync(x => x.Email == dto.Email))
            {
                return BadRequest("Email is taken!");
            }
            if(await _userManager.Users.AnyAsync(x => x.UserName == dto.Username))
            {
                return BadRequest("Username is taken!");
            }

            var user = new AppUser
            {
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                UserName = dto.Username,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return CreateUserDto(user);
            }

            return BadRequest("Problem while registering user!");
        }

        

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> getCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserDto(user);
        }

        private UserDto CreateUserDto(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
            };
        }
    }
}
