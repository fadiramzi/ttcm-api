using Microsoft.EntityFrameworkCore;
using ttcm_api.Contexts;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class TrainerService : ITrainerCRUD
    {
        private readonly MainAppContext _mainAppContext;

        public TrainerService(MainAppContext app)
        {
            _mainAppContext = app;
        }
        public async Task Create(TrainerDTO c)
        {
            Trainer t = new Trainer();
            t.Username = c.Username;
            t.Password = c.Password;
            t.Salary = c.Salary;
            t.Phone = c.Phone;
            t.Specialization = c.Specialization;
            t.Email = c.Email;
            t.Role = c.Role;
            await _mainAppContext.AddAsync(t);
            await _mainAppContext.SaveChangesAsync();

        }

       public async Task<bool> Delete(Trainer c)
        {
            try
            {
                _mainAppContext.Remove(c);
                await _mainAppContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
         
        }

        public async Task<IEnumerable<TrainerDTOResponse>> GetAll()
        {
            var list = await _mainAppContext.Trainers
                .Include(t => t.Courses)
                .Select(t => new TrainerDTOResponse
                {
                    Id = t.Id,
                    Username = t.Username,
                    Phone = t.Phone,
                    Email = t.Email,
                    Salary = t.Salary,
                    Specialization = t.Specialization,
                    Role = t.Role,
                    Courses = t.Courses.Select(c => new CourseDTOResponse { 
                            Id = c.Id,
                            Currency = c.Currency,
                            StartDate = c.StartDate,
                            EndDate = c.EndDate,
                            IsActive = c.IsActive,
                            Price = c.Price,
                            ProgramId   = c.ProgramId,
                            Program = new ProgramDTOResponseBase { 
                                Id = c.Program.Id,
                                Title = c.Program.Title,
                                Description = c.Program.Description
                            }
                            
                    })
                })
                .ToListAsync();

            return list;

        }

        public async Task<Trainer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Edit(Trainer c)
        {
            throw new NotImplementedException();
        }
    }
}
