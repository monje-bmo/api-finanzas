using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Debt;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DebtsRepository : IDebtsInterface
    {
        private readonly ApplicationDBContext ctx;

        public DebtsRepository(ApplicationDBContext context)
        {
            ctx = context;
        }

        public async Task<Debt> AddAsync(string idUser, Debt debt)
        {
            await ctx.Debts.AddAsync(debt);
            await ctx.SaveChangesAsync();
            return debt;
        }

        public async Task<Debt?> DeteleAsync(string userId, int id)
        {
            var debts = await ctx.Debts.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (debts == null) return null;

            debts.State = false;
            await ctx.SaveChangesAsync();

            // agregar el modificar el estado de las lineas.

            return debts;

        }

        public async Task<List<Debt>> GetAllAsync(string UserId)
        {
            return await ctx.Debts.Where(x => x.UserId == UserId && x.State == true).ToListAsync();
        }

        public async Task<Debt?> GetById(string userId, int id)
        {
            return await ctx.Debts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id && x.State == true);
        }

        public async Task<Debt?> UpdateAsync(string userId, int id, UpdateDebtDto dto)
        {
            var debts = await ctx.Debts.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (debts == null) return null;

            debts.BusinessID = dto.BusinessID;
            debts.Creditor = dto.Creditor;
            debts.CantInit = dto.CantInit;
            debts.CurrentBalance = dto.CurrentBalance;
            debts.StratDate = dto.StratDate;
            debts.ExpirationDate = dto.ExpirationDate;
            debts.Description = dto.Description;
            debts.State = dto.State;

            await ctx.SaveChangesAsync();

            return debts;

        }
    }
}