﻿using Microsoft.EntityFrameworkCore;
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
            _mainAppContext.Categories.Add(category);
            _mainAppContext.SaveChanges();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            // SELECT * FROM Categories
            // Join wiht Programs
            return _mainAppContext.Categories;
        }

        public async Task<bool> Delete(Category c)
        {
            _mainAppContext.Categories.Remove(c);
            await _mainAppContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> Edit(Category c)
        {
            try
            {
                _mainAppContext.Categories.Update(c);
                _mainAppContext.SaveChangesAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
               return Task.FromResult(false);
            }

        }

        public async Task<Category> GetById(int Id)
        {
           return _mainAppContext.Categories.FirstOrDefault(c => c.Id == Id);
        }
    }

}