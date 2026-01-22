using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.Business;
using api.Models;

namespace api.Mappers
{
    public static class BusinessMapper
    {
        public static BusinessDto ToBusinessDto(this Business b)
        {
            return new BusinessDto
            {
                Id = b.Id,
                Description = b.Description,
                State = b.State,
                TypeBusinessId = b.TypeBusinessId
            };
        }
    }
}