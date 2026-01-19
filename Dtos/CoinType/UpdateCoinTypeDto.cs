using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.CoinType
{
    public class UpdateCoinTypeDto
    {
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        
    }
}