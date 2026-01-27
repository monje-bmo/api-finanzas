using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.JournalHeader;
using api.Dtos.JournalLine;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DailyMovementRepo : IDailyMovement
    {
        private readonly ApplicationDBContext ctx;

        public DailyMovementRepo(ApplicationDBContext context)
        {
            ctx = context;
        }

        public async Task<JournalHeader> AddAsync(JournalHeader journalHeader)
        {
            await ctx.JournalHeaders.AddAsync(journalHeader);
            await ctx.SaveChangesAsync();
            return journalHeader;
        }


        public async Task<JournalLine> AddLineAsync(JournalLine line)
        {
            await ctx.JournalLines.AddAsync(line);
            await ctx.SaveChangesAsync();
            return line;
        }

        public async Task<JournalHeader?> DeleteAsync(string userid, int id)
        {
            var header = await ctx.JournalHeaders.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userid);

            if (header == null) return null;

            header.State = false;
            await ctx.SaveChangesAsync();

            var lines = await ctx.JournalLines.Where(l => l.JournalHeaderId == header.Id).ToListAsync();
            foreach (var line in lines)
            {
                line.State = false;
            }

            return header;
        }


        public async Task<JournalLine?> DeleteLineJournal(int id)
        {
            var line = await ctx.JournalLines.FirstOrDefaultAsync(x => x.Id == id);
            if (line == null) return null;

            line.State = false;

            await ctx.SaveChangesAsync();
            return line;
        }

        public async Task<List<JournalHeader>> GetAll(string userid)
        {
            return await ctx.JournalHeaders
            .Include(l => l.JournalLines.Where(l => l.State)
            ).Where(h => h.State && h.UserId == userid).ToListAsync();
        }

        public async Task<JournalHeader?> GetById(string userid, int id)
        {
            return await ctx.JournalHeaders
            .AsNoTracking()
            .Where(h => h.Id == id && h.State && h.UserId == userid)
            .Include(l => l.JournalLines.Where(l => l.State))
            .FirstOrDefaultAsync();
        }

        public async Task<JournalHeader?> UpdateAsync(string userid, int id, UpdateJournalHEaderDto dto)
        {
            var h = await ctx.JournalHeaders.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userid);
            if (h == null) return null;

            h.DateMove = dto.DateMove;
            h.TypeMoves = dto.TypeMoves;
            h.Description = dto.Description;

            await ctx.SaveChangesAsync();
            return h;
        }

        public async Task<JournalLine?> UpdateLineJournal(int id, UpdateJournalLineDto updateJournalLineDto)
        {
            var l = await ctx.JournalLines.FirstOrDefaultAsync(x => x.Id == id);
            if (l == null) return null;

            l.AccountId = updateJournalLineDto.AccountId;
            l.Amount = updateJournalLineDto.Amount;
            l.CategoryId = updateJournalLineDto.CategoryId;
            l.BusinessId = updateJournalLineDto.BusinessId;
            l.Note = updateJournalLineDto.Note;

            await ctx.SaveChangesAsync();
            return l;
        }
    }
}