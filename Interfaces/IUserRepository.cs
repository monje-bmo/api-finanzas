using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User userModel);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetByIdUser(int id);
        Task<User?> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<User?> DeleteUserAsync(int id);
    }
}