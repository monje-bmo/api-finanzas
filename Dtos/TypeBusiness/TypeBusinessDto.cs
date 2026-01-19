using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TypeBusiness
{
    public class TypeBusinessDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;
    }
}