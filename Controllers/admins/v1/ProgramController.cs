using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;
using ttcm_api.Models;
using ttcm_api.Services;

namespace ttcm_api.Controllers.admins.v1
{
    [Route("api/admins/v1/programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        // For Dependency Injection
        // to be fetched from DI container, auto
        // SHOULD BE ADDED to the container of DI at program.cs file
        private IProgramCRUD _programsService;
        public ProgramController(IProgramCRUD programsService)
        {
            _programsService = programsService;
        }

        // Read:R
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProgramDTOResponseCategory> programs = await _programsService.GetAll();
            return Ok(programs);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProgramDTORequestWithCategory program)
        {

            var p =await _programsService.Create(program);



            //return Ok(program);// Http 200 => success
            return CreatedAtAction("Create", new { p.Id }, program);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Program newProgram)
        {


            var newProg = _programsService.Update(id, newProgram);
            if (newProg != null)
            {
                return Ok(newProg);
            }
            // # if reach this line, this mean no resource found!
            return NotFound("The program resource not found!");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            bool isDone = await _programsService.Delete(id);
            if (isDone)
            {
                return Ok();
            }

            return NotFound();
        }


    }
}
