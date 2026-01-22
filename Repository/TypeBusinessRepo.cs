using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TypeBusiness;
using api.Helpers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TypeBusinessRepo : ITypeBusinessRepo
    {
        private readonly ApplicationDBContext ctx;
        public TypeBusinessRepo(ApplicationDBContext applicationDBContext)
        {
            ctx = applicationDBContext;
        }

        public async Task<TypeBusiness> CreateTypeBusinnesAsync(TypeBusiness typeBusiness)
        {
            await ctx.TypeBusinesses.AddAsync(typeBusiness);
            await ctx.SaveChangesAsync();
            return typeBusiness;
        }

        public async Task<TypeBusiness?> DeleteTypeBusinessAsync(int id)
        {
            var tb = await ctx.TypeBusinesses.FirstOrDefaultAsync(x => x.Id == id);
            if (tb == null)
                return null;

            ctx.TypeBusinesses.Remove(tb);
            await ctx.SaveChangesAsync();

            return tb;
        }

        public async Task<List<TypeBusiness>> GetAllTypeBusinessAsync()
        {
            return await ctx.TypeBusinesses.ToListAsync();
        }

        public async Task<TypeBusiness?> GetByIdTypeBusinessAsync(int id)
        {
            return await ctx.TypeBusinesses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TypeBusiness?> UpdateTypeBusinessAsync(int id, UpdateTypeBusinessDto typeBusiness)
        {
            var tb = await ctx.TypeBusinesses.FirstOrDefaultAsync(x => x.Id == id);
            if (tb == null) return null;

            tb.Description = typeBusiness.Description;
            tb.State = typeBusiness.State;

            await ctx.SaveChangesAsync();
            return tb;
            
        }
    }
}