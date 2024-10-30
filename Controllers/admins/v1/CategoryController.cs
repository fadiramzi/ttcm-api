using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Controllers.admins.v1
{
    [Authorize(Roles = "Admin")]
    [Route("api/admins/v1/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryCRUD _categroyService;
        public CategoryController(
            ICategoryCRUD categoryCRUD
            )
        {
            _categroyService = categoryCRUD;
        }
        [HttpGet]
        async public Task<IActionResult> GetAll()
        {

            return Ok(await _categroyService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO category)
        {

            await _categroyService.Create(category);
            return Ok("Catrgory Added Successfully");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, CategoryDTO c)
        {
            var found = await _categroyService.GetById(Id);

            if (found == null)
            {
                return NotFound();
            }
            found.Name = c.Name;
            bool isEdited = await _categroyService.Edit(found);
            if (!isEdited)
            {
                return StatusCode(500);
            }

            return Ok("Updated");
        }





    }
}
