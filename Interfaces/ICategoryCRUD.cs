using ttcm_api.DTOs;
using ttcm_api.Models;

namespace ttcm_api.Interfaces
{
    public interface ICategoryCRUD
    {
        Task Create(CategoryDTO c);
        Task<Category> GetById(int id);
        Task<bool> Delete(Category c);
        Task<bool> Edit(Category c);
        Task<IEnumerable<Category>> GetAll();


    }
}
