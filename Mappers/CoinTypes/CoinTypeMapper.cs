using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CoinType;
using api.Models;

namespace api.Mappers.CoinTypes
{
    public static class CoinTypeMapper
    {
        public static CoinType ToCoinTypeFromCreateDTO(this CreateCoinTypeDto dto)
        {
            return new CoinType
            {
                Description = dto.Description
            };
        }

        public static CoinTypeDto ToCoinTypeDto(this CoinType coinType)
        {
            return new CoinTypeDto
            {
                Id = coinType.Id,
                Description = coinType.Description,
                State = coinType.State
            };
        }
    }
}