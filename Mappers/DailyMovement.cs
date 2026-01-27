using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalHeader;
using api.Dtos.JournalLine;
using api.Models;

namespace api.Mappers
{
    public static class DailyMovement
    {
        public static MovementDto toMovementDto(this JournalHeader h)
        {
            return new MovementDto
            {
                Id = h.Id,
                DateMove = h.DateMove,
                Description = h.Description,
                TypeMoves = h.TypeMoves,
                JournalLines = h.JournalLines.Select(l => l.ToJournalLineDto()).ToList()
            };
        }


        public static JournalLineDto ToJournalLineDto(this JournalLine l)
        {
            return new JournalLineDto
            {
                Id = l.Id,
                AccountId = l.AccountId,
                Amount = l.Amount,
                BusinessId = l.BusinessId,
                CategoryId = l.CategoryId
            };
        }
    }
}

