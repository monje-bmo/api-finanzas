using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalHeader;
using api.Dtos.JournalLine;
using api.Models;

namespace api.Interfaces
{
    public interface IDailyMovement
    {
        public Task<JournalHeader> AddAsync(JournalHeader journalHeader);
        public Task<JournalHeader?> GetById(int id);
        public Task<List<JournalHeader>> GetAll();
        public Task<JournalHeader?> UpdateAsync(int id, UpdateJournalHEaderDto dto);
        public Task<JournalHeader?> DeleteAsync(int id); // eliminar todas las lineas de ese header.

        // movimineto lineas
        public Task<JournalLine> AddLineAsync(JournalLine line);

        public Task<JournalLine?> UpdateLineJournal(int id, UpdateJournalLineDto updateJournalLineDto);
        public Task<JournalLine?> DeleteLineJournal(int id);


    }
}