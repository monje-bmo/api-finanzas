using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Business
{
    public class UpdateBusinessDto
    {
        public int TypeBusinessId { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; } = true;
    }
}