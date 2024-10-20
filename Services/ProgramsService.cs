using Microsoft.EntityFrameworkCore;
using ttcm_api.Contexts;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;

namespace ttcm_api.Services
{
    public class ProgramsService : IProgramCRUD
    {
        private MainAppContext _mainAppContext;

        public ProgramsService(MainAppContext mainAppContext)
        {
            _mainAppContext = mainAppContext;
        }
        public async Task<Models.Program> Update(int id, Models.Program newProgram)
        {
            //#1 go to the programs list and get the resource
            var oldProgam = await _mainAppContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (oldProgam != null)
            {
                oldProgam.Title = newProgram.Title;
                await _mainAppContext.SaveChangesAsync();
            }

            return oldProgam;
        }

        public async Task<bool> Delete(int id)
        {
            // #1 go to the programs list and get the resource
            var program = await _mainAppContext.Programs.FirstOrDefaultAsync(p => p.Id == id);
            if (program != null)
            {
                _mainAppContext.Programs.Remove(program);
                await _mainAppContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProgramDTOResponseCategory>> GetAll()
        {
            var programs = await _mainAppContext.Programs
                .Include(p => p.Category)
                 .Select(p=> new ProgramDTOResponseCategory { 
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        Category = new CategoryDTOResponse { 
                            Id = p.Category.Id,
                            Name = p.Category.Name,
                        }
                    })
                .ToListAsync();
            return programs;
        }

       public async Task<Models.Program> Create(ProgramDTORequestWithCategory p)
        {
           Models.Program model = new Models.Program();
            model.Title = p.Title;
            model.Description = p.Description;
            model.CategoryId = p.CategoryId;

            await  _mainAppContext.Programs.AddAsync(model);
            await _mainAppContext.SaveChangesAsync();

            return model;
        }

      

    }
}
