using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.Business;
using api.Dtos.Category;
using api.Dtos.Debt;
using api.Dtos.JournalHeader;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password_hash { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.Now;

        public List<BusinessDto> Businesses { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<AccountDto> Accounts { get; set; }
        public List<JournalHeaderDto> JournalHeaders { get; set; }

        public List<DebtDto> Debts { get; set; }
 
    }
}