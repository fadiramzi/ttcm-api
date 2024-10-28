using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.DTOs;
using ttcm_api.Models;
using ttcm_api.Services;

namespace ttcm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtService _jwtService;

        public AuthController(
            
            UserManager<User> userManager, SignInManager<User> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
        {
            var user = await _userManager.FindByNameAsync(authRequest.Username);
            
            if (user == null)
            {
                return Unauthorized("User not authenticated");
            }
            
           var Result = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (!Result.Succeeded)
            {
                
                return Unauthorized("User not authenticated");
            }
            // Generate JWT
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateJWT(user, roles[0]);
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] DTOs.RegisterRequest registerRequest)
        {
            var user = new Trainer { 
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                Salary = 2500,
                Specialization = "Programming"

            };
            var Result = await _userManager.CreateAsync(user, registerRequest.Password);
            if(!Result.Succeeded)
            {
                return StatusCode(500, "User not created");
            }

            return Ok("Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AssignRole(int id, [FromBody] AssignRoleRequest assignRoleRequest)
        {
           var User = await  _userManager.FindByIdAsync(id.ToString());
            if (User == null)
            {
                return NotFound("User not exists");
            }
            var Result =  await _userManager.AddToRoleAsync(User, assignRoleRequest.RoleName);
            
            if (!Result.Succeeded) {
                return StatusCode(500, "Not completed");
            }

            return Ok("Role Added");


        }


    }
}
