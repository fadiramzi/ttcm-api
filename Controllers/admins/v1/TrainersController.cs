using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Contexts;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;
using ttcm_api.Services;

namespace ttcm_api.Controllers.admins.v1
{
    [Route("api/admins/v1/trainers")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerCRUD _trainerService;
        public TrainersController(ITrainerCRUD trainerService) {
            _trainerService = trainerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TrainerDTO trainerDTO)
        {
            await _trainerService.Create(trainerDTO);

            return Ok("Trainer Created");
        }


        [HttpGet]
        public async Task<IEnumerable<TrainerDTOResponse>> GetAll()
        {
            return await _trainerService.GetAll();
        }
    }
}
