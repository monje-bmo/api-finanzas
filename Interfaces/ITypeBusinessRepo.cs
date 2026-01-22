using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TypeBusiness;
using api.Models;

namespace api.Helpers
{
    public interface ITypeBusinessRepo
    {
        public Task<TypeBusiness> CreateTypeBusinnesAsync(TypeBusiness typeBusiness);
        public Task<List<TypeBusiness>> GetAllTypeBusinessAsync();
        public Task<TypeBusiness?> GetByIdTypeBusinessAsync(int id);
        public Task<TypeBusiness?> UpdateTypeBusinessAsync(int id, UpdateTypeBusinessDto typeBusiness);
        public Task<TypeBusiness?> DeleteTypeBusinessAsync(int id); 
    }
}