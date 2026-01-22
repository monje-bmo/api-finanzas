using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ICoinTypeRepository
    {
        public Task<List<CoinType>> GetAllAsync();
        public Task<CoinType?> GetByIdAsync(int id);
        public Task<CoinType> CreateAsync(CoinType coinType);
        public Task<CoinType?> UpdateAsync(int id, CoinType coinType);
        public Task<CoinType?> DeleteAsync(int id);

    }
}