using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace firstback.user
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<int> CreateUserAsync(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
               _mapper.Map(userDTO, user);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
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