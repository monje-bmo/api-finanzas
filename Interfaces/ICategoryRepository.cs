using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        
        public Task<Category> CreateCategoryAsync(Category category);
        public Task<List<Category>> GetAllCategoryAsync(string userId); 
        public Task<Category?> GetCategoryByIdAsync(string userId, int id);
        public Task<Category?> UpdateCategoryAsync(string userId, int id, UpdateCategoryDto updateCategoryDto);
        public Task<Category?> DeleteCategoryAsync(string userId, int id);
    }
}