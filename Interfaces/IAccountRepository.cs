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
        public Task<Account?> GetByIdAsync(int id);
        public Task<List<Account>> GetAllAsync();
        public Task<Account?> UpdateAsync(int id, UpdateAccountDto dto);
        public Task<Account?> DeleteAsync(int id);

    }
}