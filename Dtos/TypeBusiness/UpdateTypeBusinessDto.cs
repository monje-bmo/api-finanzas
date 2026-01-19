using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TypeBusiness
{
    public class UpdateTypeBusinessDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

    }
}