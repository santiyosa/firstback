using BackendProject.DTOs;
using BackendProject.Models;


namespace BackendProject.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(int id, UserDTO userDTO);
        Task DeleteUserAsync(int id);
    }
}