using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly ApplicationDBContext _ctx;
        public CategoryRepository(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _ctx.Categories.AddAsync(category);
            await _ctx.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategoryAsync(string userId, int id)
        {
            var cateory = await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if(cateory == null)
                return null;
            _ctx.Categories.Remove(cateory);
            await _ctx.SaveChangesAsync();
            return cateory;
        }

        public async Task<List<Category>> GetAllCategoryAsync(string userId)
        {
            return await _ctx.Categories.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(string userId, int id)
        {
            return await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<Category?> UpdateCategoryAsync(string userId, int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if(category == null)
                return category;
            
            category.Description = updateCategoryDto.Description;
            category.Type_category = updateCategoryDto.Type_category;
            category.State = updateCategoryDto.State;

            await _ctx.SaveChangesAsync();
            return category;
        }
    }
}