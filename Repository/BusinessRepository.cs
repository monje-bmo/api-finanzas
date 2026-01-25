using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Business;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ApplicationDBContext _ctx;
        public BusinessRepository(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Business> CreateBussinesAsync(Business business)
        {
            await _ctx.Businesses.AddAsync(business);
            await _ctx.SaveChangesAsync();
            return business;
        }

        public async Task<Business?> DeleteBussinesAsync(string userId, int id)
        {
            var b = await _ctx.Businesses.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (b == null)
                return null;
            _ctx.Businesses.Remove(b);
            await _ctx.SaveChangesAsync();
            return b;
        }

        public async Task<List<Business>> GetAllBussinesAsync(string userId)
        {
            return await _ctx.Businesses.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Business?> GetById(string userId, int id)
        {

            return await _ctx.Businesses.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<Business?> UpdateBussinesAsync(string userId, int id, UpdateBusinessDto dto)
        {
            var b = await _ctx.Businesses.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (b == null)
                return null;

            b.TypeBusinessId = dto.TypeBusinessId;
            b.Description = dto.Description;
            b.State = dto.State;

            await _ctx.SaveChangesAsync();

            return b;
        }
    }
}