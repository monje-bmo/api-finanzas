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


        public async Task<Account?> DeleteAsync(int id)
        {
            var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (account == null) return null;

            ctx.Accounts.Remove(account);
            await ctx.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await ctx.Accounts.ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Account?> UpdateAsync(int id, UpdateAccountDto dto)
        {
            var account = await ctx.Accounts.FirstOrDefaultAsync(x => x.Id == id);
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