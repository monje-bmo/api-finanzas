using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Business;
using api.Models;

namespace api.Interfaces
{
    public interface IBusinessRepository
    {
        public Task<List<Business>> GetAllBussinesAsync();
        public Task<Business?> GetById(int id);
        public Task<Business> CreateBussinesAsync(Business business);
        public Task<Business?> UpdateBussinesAsync(int id, UpdateBusinessDto dto);
        public Task<Business?> DeleteBussinesAsync(int id); 
    }
}