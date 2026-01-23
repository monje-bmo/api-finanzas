using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Dtos.Business;
using api.Dtos.TypeBusiness;
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

        public static BusinessDtoAll ToBusinessAllDto(this Business b)
        {
            return new BusinessDtoAll
            {
                Description = b.Description
            };
        }
        
        public static Business DtoToBusiness( this CreateBusinessDto dto )
        {
            return new Business
            {
                TypeBusinessId = dto.TypeBusinessId,
                Description = dto.Description
            };
        }

        public static TypeBusiness CreateDtoToTypeBusiness(this CreateTypeBusinessDto dto)
        {
            return new TypeBusiness
            {
              Description = dto.Description  
            };
        }

        public static TypeBusinessDto TypeBusinessDto(this TypeBusiness typeBusiness)
        {
            return new TypeBusinessDto
            {
                Description = typeBusiness.Description,
            };
        } 
    }
}