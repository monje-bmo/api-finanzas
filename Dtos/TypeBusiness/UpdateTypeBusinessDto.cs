using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TypeBusiness
{
    public class UpdateTypeBusinessDto
    {
        public string Description { get; set; } = string.Empty;

        public bool State { get; set; }
    }
}