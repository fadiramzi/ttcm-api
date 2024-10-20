using ttcm_api.DTOs;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ITrainerCRUD
    {
        Task Create(TrainerDTO c);
        Task<Trainer> GetById(int id);
        Task<bool> Delete(Trainer c);
        Task<bool> Edit(Trainer c);
        Task<IEnumerable<TrainerDTOResponse>> GetAll();
    }
}
