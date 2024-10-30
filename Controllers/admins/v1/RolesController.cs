using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ttcm_api.Models;

namespace ttcm_api.Controllers.admins.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {

            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]string RoleName)
        {
            await _roleManager.CreateAsync(new ApplicationRole(RoleName));
            return Ok("Done");
        }
    }
}
