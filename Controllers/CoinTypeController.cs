using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CoinType;
using api.Interfaces;
using api.Mappers.CoinTypes;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/coinType")]
    [ApiController]
    public class CoinTypeController : ControllerBase
    {

        private readonly ICoinTypeRepository _repo;

        public CoinTypeController(ICoinTypeRepository coin_repo)
        {
            _repo = coin_repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cointype = await _repo.GetAllAsync();
            
            return Ok(
                cointype.Select(c => c.ToCoinTypeDto())
            );
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coin = await _repo.GetByIdAsync(id);
            if (coin == null)
                return NotFound();
            return Ok(coin.ToCoinTypeDto());
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCoinTypeDto createCoinTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coinModel = createCoinTypeDto.ToCoinTypeFromCreateDTO();

            await _repo.CreateAsync(coinModel);

            return CreatedAtAction(
                nameof(GetById),
                new { id = coinModel.Id },
                coinModel.ToCoinTypeDto()
            );
        }

    }
}