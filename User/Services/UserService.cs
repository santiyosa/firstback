using BackendProject.Data;
using BackendProject.DTOs;
using BackendProject.Models;
using Microsoft.EntityFrameworkCore;


namespace BackendProject.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                BirthDate = userDTO.BirthDate,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.BirthDate = userDTO.BirthDate;
            user.Password = userDTO.Password;
            user.Role = userDTO.Role;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}