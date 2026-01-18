using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TypeBusiness
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
        public DateTime Update_at { get; set; } = DateTime.UtcNow;

        public List<Business> Business { get; set; } = new List<Business>();
    }
}