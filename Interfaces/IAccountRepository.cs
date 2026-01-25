using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        public Task<Account> CreateAsync(Account account);
        public Task<Account?> GetByIdAsync(string userId, int id);
        public Task<List<Account>> GetAllAsync(string userId);
        public Task<Account?> UpdateAsync(string userId, int id, UpdateAccountDto dto);
        public Task<Account?> DeleteAsync(string userId, int id);

    }
}