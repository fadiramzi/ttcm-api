using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Models;

namespace ttcm_api.Controllers.admins.v1
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UsersController(UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) {
               _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPut("{id}/assignRole")]
        public async Task<IActionResult> AssignRole(int id , [FromBody] string RoleName)
        {
            // Get role and check if it exists in the DB
            var role = _roleManager.GetRoleNameAsync(new ApplicationRole(RoleName));
            if (role == null)
            {
                return NotFound("Role Not Found");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null) 
            {
                return NotFound("User Not Found");
            }
            var haveRole = await _userManager.IsInRoleAsync(user, RoleName);
            if(haveRole == true)
            {
                return Conflict("This role is already assigned to the user");
            }
            await _userManager.AddToRoleAsync(user, RoleName);

            return Ok("Role Added");
        }

    }
}
