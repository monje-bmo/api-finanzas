using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.JournalHeader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/dailyMovement")]
    [Authorize]
    public class DailyMovementController : ControllerBase
    {

        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            return Ok();
        }


        // public async Task<IActionResult> Create(CreateJournalHeaderDto dto)
        // {
            
        // }

    }
}