using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;

namespace api.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this Account account)
        {
            return new AccountDto
            {
                Id = account.Id,
                Name = account.Name,
                TypeAccount = account.TypeAccount,
                CoinTypeId = account.CoinTypeId,
                OpeningBalance = account.OpeningBalance,
                DateOpeningBalance = account.DateOpeningBalance,
            };
        }

        public static Account ToDtoFromAccount(this CreateAccountDto dto)
        {
            return new Account
            {
                Name = dto.Name,
                TypeAccount = dto.TypeAccount,
                CoinTypeId = dto.CoinTypeId,
                OpeningBalance = dto.OpeningBalance,
                DateOpeningBalance = dto.DateOpeningBalance,
            };
        }

    }
}