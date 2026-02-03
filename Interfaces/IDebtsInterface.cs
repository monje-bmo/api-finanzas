using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Debt;
using api.Models;

namespace api.Interfaces
{
    public interface IDebtsInterface
    {

        public Task<List<Debt>> GetAllAsync(string UserId);
        public Task<Debt?> GetById(string userId, int id);
        public Task<Debt> AddAsync(string idUser, Debt debt);
        public Task<Debt?> UpdateAsync(string userId, int id, UpdateDebtDto dto);
        public Task<Debt?> DeteleAsync(string userId,int id);
        
    }
}