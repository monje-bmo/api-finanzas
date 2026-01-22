using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CoinType;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CoinTypeRepository : ICoinTypeRepository
    {
        private readonly ApplicationDBContext _context;
        public CoinTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CoinType> CreateAsync(CoinType coinType)
        {
            await _context.CoinTypes.AddAsync(coinType);
            await _context.SaveChangesAsync();
            return coinType;
        }

        public async Task<CoinType?> DeleteAsync(int id)
        {
            var coinModel = await _context.CoinTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (coinModel == null)
                return null;

            _context.CoinTypes.Remove(coinModel);
            await _context.SaveChangesAsync();
            return coinModel;
        }

        public async Task<List<CoinType>> GetAllAsync()
        {
            return await _context.CoinTypes.ToListAsync();

        }

        public async Task<CoinType?> GetByIdAsync(int id)
        {
            return await _context.CoinTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CoinType?> UpdateAsync(int id, UpdateCoinTypeDto coinType)
        {
            var coinModel = await _context.CoinTypes.FirstOrDefaultAsync(x => x.Id == id);
            if (coinModel == null)
                return null;

            coinModel.Description = coinType.Description;
            coinModel.State = coinType.State;

            return coinModel;

        }
    }
}