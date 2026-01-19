using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CoinType
{
    public class CoinTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
    }
}