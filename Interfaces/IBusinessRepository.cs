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
        public Task<List<Business>> GetAllBussinesAsync(string userId);
        public Task<Business?> GetById(string userId, int id);
        public Task<Business> CreateBussinesAsync(Business business);
        public Task<Business?> UpdateBussinesAsync(string userId, int id, UpdateBusinessDto dto);
        public Task<Business?> DeleteBussinesAsync(string userId, int id); 
    }
}