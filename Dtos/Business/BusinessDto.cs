using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalLine;

namespace api.Dtos.Business
{
    public class BusinessDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeBusinessId { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; } = true;
        public DateTime Created_at { get; set; } 
        public DateTime Update_at { get; set; } 
        public List<JournalLineDto> JournalLines { get; set; }

    }
}