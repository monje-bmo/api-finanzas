using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
     
        // // Relaciones con las tablas
        // public List<Business> Businesses { get; set; } = new List<Business>();
        // public List<Category> Categories { get; set; } = new List<Category>();
        // public List<Account> Accounts { get; set; } = new List<Account>();
        // public List<JournalHeader> JournalHeaders { get; set; } = new List<JournalHeader>();

        // public List<Debt> Debts { get; set; } = new List<Debt>();
    }
}