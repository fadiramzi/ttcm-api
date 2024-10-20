using ttcm_api.DTOs;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface IProgramCRUD
    {
        public Task<IEnumerable<ProgramDTOResponseCategory>> GetAll();
        public Task<ttcm_api.Models.Program> Create(ProgramDTORequestWithCategory p);
        public Task<ttcm_api.Models.Program> Update(int id, ttcm_api.Models.Program newProgram);
        public Task<bool> Delete(int id);


    }
}
