using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CoinType
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;

    }
}