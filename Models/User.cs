using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password_hash { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.Now;

        // Relaciones con las tablas
        public List<Business> Businesses { get; set; } = new List<Business>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<JournalHeader> JournalHeaders { get; set; } = new List<JournalHeader>();

        public List<Debt> Debts { get; set; } = new List<Debt>();
    }
}