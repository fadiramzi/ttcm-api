using Microsoft.EntityFrameworkCore;
using ttcm_api.Contexts;
using ttcm_api.DTOs;
using ttcm_api.Interfaces;
using ttcm_api.Models;

namespace ttcm_api.Services
{
    public class CategoryService : ICategoryCRUD

    {
        private MainAppContext _mainAppContext;

        public CategoryService(MainAppContext mainAppContext)
        {
            _mainAppContext = mainAppContext;
        }
        public async Task Create(CategoryDTO c)
        {
            Category category = new Category();
            category.Name = c.Name;
            await _mainAppContext.Categories.AddAsync(category);
            await _mainAppContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            // SELECT * FROM Categories
            // Join wiht Programs
            return await _mainAppContext.Categories.ToListAsync();
        }

        public async Task<bool> Delete(Category c)
        {
            _mainAppContext.Categories.Remove(c);
            await _mainAppContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(Category c)
        {
            try
            {
                _mainAppContext.Categories.Update(c);
                _mainAppContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }

        public async Task<Category> GetById(int Id)
        {
            Category c = await _mainAppContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);


            return c;
        }
    }

}
