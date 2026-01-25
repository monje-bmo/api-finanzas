using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AccountRepo : IAccountRepository
    {
        private readonly ApplicationDBContext ctx;

        public AccountRepo(ApplicationDBContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<Account> CreateAsync(Account account)
        {
            await ctx.Accounts.AddAsync(account);
            await ctx.SaveChangesAsync();
            return account;
        }


        public async Task<Account?> DeleteAsync(string userId, int id)
        {
            var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (account == null) return null;

            ctx.Accounts.Remove(account);
            await ctx.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetAllAsync(string userId)
        {
            return await ctx.Accounts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(string userId, int id)
        {
            return await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<Account?> UpdateAsync(string userId, int id, UpdateAccountDto dto)
        {
            var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (account == null) return null;

            account.Name = dto.Name;
            account.TypeAccount = dto.TypeAccount;
            account.CoinTypeId = dto.CoinTypeId;
            account.OpeningBalance = dto.OpeningBalance;
            account.DateOpeningBalance = dto.DateOpeningBalance;
            account.State = dto.State;

            await ctx.SaveChangesAsync();
            return account;
        }
    }
}