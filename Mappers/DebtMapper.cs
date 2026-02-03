using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Debt;
using api.Dtos.DebtMovement;
using api.Models;

namespace api.Mappers
{
    public static class DebtMapper
    {
        public static DebtDto ToDebtDto(this Debt debt)
        {
            return new DebtDto
            {
                Id = debt.Id,
                BusinessID = debt.BusinessID,
                Creditor = debt.Creditor,
                CantInit = debt.CantInit,
                CurrentBalance = debt.CurrentBalance,
                StratDate = debt.StratDate,
                ExpirationDate = debt.ExpirationDate,
                Description = debt.Description,
                State = debt.State,
                CreatedAt = debt.CreatedAt,
                DebtMovements = debt.DebtMovements.Select(d => d.ToMoveDebtDto()).ToList()
            };
        }

        public static DebtMovementDto ToMoveDebtDto(this DebtMovement debtMovement)
        {
            return new DebtMovementDto
            {
                Id = debtMovement.Id,
                DebtId = debtMovement.DebtId,
                JournalHeaderId = debtMovement.JournalHeaderId,
                CapitalAmount = debtMovement.CapitalAmount,
                InterestAmount = debtMovement.InterestAmount,
                CreatedAt = debtMovement.CreatedAt
            };
        }

    }
}